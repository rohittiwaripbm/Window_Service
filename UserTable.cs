namespace WindowsService1
{
    public class UserTable
    {
        #region Properties
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        private int? _mob_no;

        public int? Mobile_no
        {
            get { return _mob_no; }
            set { _mob_no = value; }
        }

        private bool? _isActive;

        public bool? IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }





        #endregion
    }
}
