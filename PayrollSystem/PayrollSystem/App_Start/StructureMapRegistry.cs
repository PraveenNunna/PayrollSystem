using StructureMap;
using StructureMap.Graph;
using PayrollSystem.Abstractions;

namespace PayrollSystem.App_Start
{
    public class StructureMapRegistry :Registry
    {
        public StructureMapRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IPayrollService>().Use<Implementations.PayrollService>();
        }
    }
}