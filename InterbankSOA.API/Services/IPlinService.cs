using InterbankSOA.API.Models;

namespace InterbankSOA.API.Services
{
    public interface IPlinService
    {
        PlinearResponse ProcesarPlin(PlinearRequest request);
    }
}
