using Bank_mangement_system.DTOs;

namespace Bank_mangement_system.Rpos.IRepo
{
    public interface ICustomerRepo
    {
        void AddCustomerreated(Customerdto customerdto);
        Customerdto getCustomerbyId(int id);
    }
}
