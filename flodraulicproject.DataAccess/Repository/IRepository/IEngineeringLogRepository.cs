using flodraulicproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository.IRepository
{
    public interface IEngineeringLogRepository : IRepository<EngineeringLog>
    {

        void Update(EngineeringLog obj);

    }
}
