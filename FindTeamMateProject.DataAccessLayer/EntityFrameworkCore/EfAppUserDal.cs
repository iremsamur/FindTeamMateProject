using FindTeamMateProject.DataAccessLayer.Abstract;
using FindTeamMateProject.DataAccessLayer.Repository;
using FindTeamMateProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTeamMateProject.DataAccessLayer.EntityFrameworkCore
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {

    }
}
