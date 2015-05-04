namespace DynaStudios.DPCFLib.Format.Reader
{
    public interface IReader<out T>
    {
        T ReadHeader();
    }
}