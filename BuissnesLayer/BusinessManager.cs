using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BusinessManager
    {
        public IUserTaskRepository UserTaskRepositiry { get { return _userTaskRepositiry; } }

        private IUserTaskRepository _userTaskRepositiry;
      
        public BusinessManager(IUserTaskRepository userTaskRepositiry)
        {
            _userTaskRepositiry = userTaskRepositiry;
        }
    }
}
