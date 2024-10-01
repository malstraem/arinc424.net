namespace Arinc424.Processing;

internal interface ITrigger<T>
{
    static abstract bool Check(T one, T another);
}
