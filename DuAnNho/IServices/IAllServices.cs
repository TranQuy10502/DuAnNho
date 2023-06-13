namespace DuAnNho.IServices
{
    public interface IAllServices<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
