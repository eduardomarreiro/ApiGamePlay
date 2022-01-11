using ApiGamePlay.Domain.Interfaces.IRepository;
using ApiGamePlay.Domain.Models;
using ApiGamePlay.Shared.Dto.Create;
using ApiGamePlay.Shared.Dto.Read;
using ApiGamePlay.Shared.Dto.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Application.Services
{
    public class UserService
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AdicionarUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _userRepository.Adicionar(user);
        }

        public List<ReadUserDto> ConsultaUser()
        {
            List<User> users = _userRepository.RetornarTodos();
            return _mapper.Map<List<ReadUserDto>>(users);          
        }

        public ReadUserDto ConsultarUserPorId(int id)
        {
            User user = _userRepository.RetornarPorId(id);
            if(user != null)
            {
                ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
                return userDto;
            }
            else
            {
                return null;
            }
        }

        public void ModificarUser(int id, UpdateUserDto userDto)
        {
            User user = _userRepository.RetornarPorId(id);
            if(user != null)
            {
                user.Id = id;
                user.Username = userDto.Username;
                user.Password = userDto.Password;
                user.Email = userDto.Email;
                user.Role = userDto.Role;
                _userRepository.Atualizar(user);
            }
        }
        public void DeletarUserPorId(int id)
        {
            User user = _userRepository.RetornarPorId(id);
            if( user != null)
            {
                _userRepository.Deletar(user);
            }
        }
    }
}
