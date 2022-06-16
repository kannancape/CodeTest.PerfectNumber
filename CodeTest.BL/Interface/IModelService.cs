using CodeTest.Model.Response;

namespace CodeTest.BL.Interface
{
    public interface IModelService
    {
        List<PerfectNumberOutput> GetPerfectNumber(int startNo, int endNo);
    }
}
