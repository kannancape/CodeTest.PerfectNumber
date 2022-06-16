using CodeTest.BL.Interface;
using CodeTest.Model.Response;

namespace CodeTest.BL
{
    public class ModelService : IModelService
    {
        public ModelService()
        {

        }
        public List<PerfectNumberOutput> GetPerfectNumber(int startNo, int endNo)
        {

            int numberToStart = startNo;
            List<PerfectNumberOutput> value = new List<PerfectNumberOutput>();
            for (numberToStart = startNo; numberToStart <= endNo; numberToStart++)
            {
                int i = 1;
                int sum = 0;
                while (i < numberToStart)
                {
                    if (numberToStart % i == 0)
                    {
                        sum += i;
                    }

                    i++;
                }
                if (sum == numberToStart)
                    value.Add(new PerfectNumberOutput(numberToStart));
            }
            return value;
        }
    }
}
