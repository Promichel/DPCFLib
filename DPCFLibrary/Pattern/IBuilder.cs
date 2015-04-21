namespace DynaStudios.DPCFLib.Pattern
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
