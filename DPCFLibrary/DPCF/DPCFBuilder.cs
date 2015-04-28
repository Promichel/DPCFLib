using DynaStudios.DPCFLib.Format;
using DynaStudios.DPCFLib.Pattern;
using DynaStudios.DPCFLib.Solutions;

namespace DynaStudios.DPCFLib.DPCF
{
    public class DPCFBuilder : IBuilder<DPCFFile>
    {
        public DPCFBuilder LoadFromSolution(ProjectSolution solution)
        {
            var description = solution.Description;
            var files = solution.Files;



            return this;
        }

        public DPCFFile Build()
        {
            return new DPCFFile();
        }
    }
}
