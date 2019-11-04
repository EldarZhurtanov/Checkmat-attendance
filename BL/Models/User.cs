using DevExpress.Mvvm;
using DL;

namespace BL
{
    public class User : BindableBase
    {
        public int Id { get; set; }
        public Presence Presence { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string CardNumber { get; set; }
    }
}
