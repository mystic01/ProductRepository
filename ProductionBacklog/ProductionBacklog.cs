using System;
using System.Collections.Generic;

namespace ProductionBacklog
{
    public class ProductionBacklog
    {
        private IEnumerable<Production> _prodCollection;

        public ProductionBacklog(IEnumerable<Production> prodCollection)
        {
            _prodCollection = prodCollection;
        }

        /// <summary>
        /// 回傳指定 Production 屬性的集合加總值列表（最後剩下的自成一組加總）
        /// </summary>
        /// <param name="collectionSize">每組的數量</param>
        /// <param name="prodAttriName">指定的 Production 屬性</param>
        /// <returns></returns>
        public IEnumerable<int> GetCollectionSummary(int collectionSize, string prodAttriName)
        {
            List<int> resultCollectionSummary = new List<int>();

            if (collectionSize <= 0)
                throw new ArgumentException("Collection size must larger than 0.");

            int summary = 0;
            int sizeCount = 0;
            foreach (var prod in _prodCollection)
            {
                int? num = (int?) prod.GetType().GetProperty(prodAttriName).GetValue(prod, null);

                if (num == null)
                    throw new ArgumentException("No this produciton attribute in Production : " + prodAttriName);
                else
                    summary += num.GetValueOrDefault();

                sizeCount++;
                if (sizeCount >= collectionSize)
                {
                    resultCollectionSummary.Add(summary);
                    summary = 0;
                    sizeCount = 0;
                }
            }

            if (sizeCount > 0)
                resultCollectionSummary.Add(summary);

            return resultCollectionSummary;
        }
    }
}