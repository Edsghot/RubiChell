using _0._0.DataTransferLayer.Objects;
using _1._0.HelpersLayer.Helper;
using _4._0.RepositoryLayer.Repository;
using _5._0.DataAccessLayer.Connection;
using _5._0.DataAccessLayer.Entities;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace _5._0.DataAccessLayer.Query
{
    public class QUser : RepoUser
    {
        public Boolean delete(string id)
        {
            using DataBaseContext dbc = new();
            
            User user = dbc.Users.Find(id);

            if (user is null)
            {
                return false;
            }

            dbc.Users.Remove(user);
            dbc.SaveChanges();
            return true;

        }

        public List<DtoUser> getAll()
        {
            using DataBaseContext dbc = new();

            List<User> listUser = dbc.Users.ToList();

            List<DtoUser> listDtoUser = new List<DtoUser>();

            for(int i = 0; i < listUser.Count; i++)
            {
                DtoUser dtoUser = new();

                dtoUser.idUser = listUser[i].idUser;
                dtoUser.mail = listUser[i].mail;
                dtoUser.firstName = listUser[i].firstName;
                dtoUser.password = listUser[i].password;
                dtoUser.surName = listUser[i].surName;
                dtoUser.dni = listUser[i].dni;
                dtoUser.birthDate = listUser[i].birthDate;
                dtoUser.gender = listUser[i].gender;
                dtoUser.registerDate = listUser[i].registerDate;
                dtoUser.modificationDate = listUser[i].modificationDate;

                listDtoUser.Add(dtoUser);
            }

            return listDtoUser;
        }

        public DtoUser getByPk(string pk)
        {
            using DataBaseContext dbc = new();

            User user = dbc.Users.Find(pk);

            DtoUser dtoUser = null;

            if (user is not null)
            {
                dtoUser = new();

                dtoUser.idUser = user.idUser;
                dtoUser.mail = user.mail;
                dtoUser.firstName = user.firstName;
                dtoUser.surName = user.surName;
                dtoUser.password = user.password;
                dtoUser.dni = user.dni;
                dtoUser.birthDate = user.birthDate;
                dtoUser.gender = user.gender;
                dtoUser.registerDate = user.registerDate;
                dtoUser.modificationDate = user.modificationDate;
            }

            return dtoUser;
        }

        public Boolean insert(DtoUser dto)
        {
            using DataBaseContext dbc = new();

            var newUser = new User
            {
                idUser = dto.idUser,
                dni = dto.dni,
                mail = dto.mail,
                password = dto.password,
                firstName = dto.firstName,
                surName = dto.surName,
                birthDate = dto.birthDate,
                gender = dto.gender,
                registerDate = dto.registerDate,
            };
            try
            {
                dbc.Users.Add(newUser);
                dbc.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool update(DtoUser dto)
        {
            using DataBaseContext dbc = new();

            User user = dbc.Users.Find(dto.idUser);

            user.dni = dto.dni;
            user.mail = dto.mail;
            user.password = dto.password;
            user.firstName = dto.firstName;
            user.surName = dto.surName;
            user.birthDate = dto.birthDate;
            user.gender = dto.gender;
            user.registerDate = dto.registerDate;
           
            try
            {
                dbc.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DtoUser login(string mail,string password)
        {
            using DataBaseContext dbc = new();

            User userBy = dbc.Users.FirstOrDefault(x=> x.mail== mail && x.password == password);
            DtoUser dtoUser = null;
            if (userBy != null)
            {
                User user = dbc.Users.Find(userBy.idUser);

                if (user is not null)
                {
                    dtoUser = new();

                    dtoUser.idUser = user.idUser;
                    dtoUser.mail = user.mail;
                    dtoUser.firstName = user.firstName;
                    dtoUser.surName = user.surName;
                    dtoUser.password = user.password;
                    dtoUser.dni = user.dni;
                    dtoUser.birthDate = user.birthDate;
                    dtoUser.gender = user.gender;
                    dtoUser.registerDate = user.registerDate;
                    dtoUser.modificationDate = user.modificationDate;
                }
            }
                return dtoUser;
            
        }

        public Boolean existsUser(string mail)
        {
            using DataBaseContext dbc = new();

            User userBy = dbc.Users.FirstOrDefault(x => x.mail == mail);

            if (userBy != null)
            {
                return true;
            }
            return false;
        }

        public string getPassword(string id)
        {
            using DataBaseContext dbc = new();

            User userBy = dbc.Users.Find(id);

            if (userBy != null)
            {
                return userBy.password;
            }
            return null;
        }

        public Boolean existsUserByDni(string dni)
        {
            using DataBaseContext dbc = new();

            User userBy = dbc.Users.FirstOrDefault(x => x.dni == dni);

            if (userBy != null)
            {
                return true;
            }
            return false;
        }


    }
}