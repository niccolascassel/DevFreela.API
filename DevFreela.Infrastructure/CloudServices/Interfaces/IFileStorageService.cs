namespace DevFreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UplodFile(byte[] bytes, string fileName);
    }
}
