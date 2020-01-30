namespace Enginex.Application.Mapping
{
    public interface IMapper<in TSource, out TTarget>
    {
        TTarget Map(TSource source);
    }
}
