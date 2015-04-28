namespace DynaStudios.DPCFLib.Format.Writer
{
    public interface IWriter<in T>
    {
        void Write(T headerStruct);
    }
}