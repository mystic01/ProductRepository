using System;
using System.Collections.Generic;

namespace ProductRepository
{
    public class ProductRepository
    {
        private IEnumerable<Product> _productList;

        public ProductRepository(IEnumerable<Product> productList)
        {
            _productList = productList;
        }

        /// <summary>
        /// 回傳指定 Product 屬性的集合加總值列表（最後剩下的自成一組加總）
        /// </summary>
        /// <param name="partSize">每組的數量</param>
        /// <param name="productProperty">指定的 Product 屬性</param>
        /// <returns></returns>
        public IEnumerable<int> GetPartSum(int partSize, string productProperty)
        {
            List<int> resultPartSum = new List<int>();

            if (partSize <= 0)
                throw new ArgumentException("part size must larger than 0.");

            int sum = 0;
            int sizeCount = 0;
            foreach (var prod in _productList)
            {
                int? num = (int?) prod.GetType().GetProperty(productProperty).GetValue(prod, null);

                if (num == null)
                    throw new ArgumentException("No this product property in Product : " + productProperty);
                else
                    sum += num.GetValueOrDefault();

                sizeCount++;
                if (sizeCount >= partSize)
                {
                    resultPartSum.Add(sum);
                    sum = 0;
                    sizeCount = 0;
                }
            }

            if (sizeCount > 0)
                resultPartSum.Add(sum);

            return resultPartSum;
        }
    }
}