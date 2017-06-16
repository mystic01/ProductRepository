using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductRepository
{
    public class ProductRepository
    {
        /// <summary>
        /// 回傳指定 Product 屬性的集合加總值列表（最後剩下的自成一組加總）
        /// </summary>
        /// <param name="partSize">每組的數量</param>
        /// <param name="productProperty">指定的 Product 屬性</param>
        /// <returns></returns>
        public static IEnumerable<int> GetPartSum(IEnumerable<Product> products, int partSize, Func<Product, int> selector)
        {
            if (partSize <= 0)
                throw new ArgumentException("part size must larger than 0.");

            var productsList = products.ToList();
            int index = 0;
            while (index < productsList.Count)
            {
                yield return productsList.Skip(index).Take(partSize).Sum(selector);
                index += partSize;
            }
        }
    }
}