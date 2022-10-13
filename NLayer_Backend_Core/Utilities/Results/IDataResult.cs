namespace NLayer_Backend_Core.Utilities.Results
{
    //ikiside interface oldugundan IResult implement ettiğimizde classlardaki implement etmez ama
    //içindekiş işlemleride dahil ediyor.Yani IResult da yer alan Success,Message alanlarıda yer alıyor.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
