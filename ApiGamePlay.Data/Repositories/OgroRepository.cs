using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class OgroRepository : Repository<Ogro>, IOgroRepository
    {
        IMapper _mapper;

        public OgroRepository(GamePlayContext context) : base(context)
        {
            _context = context;
        }
    }
        //public void DeletandoOgros(int min, int max)
        //{
        //    List<Ogro> Ogros = _context.Ogros.ToList();
        //    int QtdOgros = Ogros.Count;
        //    if (QtdOgros == 0)
        //    {
        //        return Ok();
        //    }
        //    foreach (var Ogro in Ogros)
        //    {
        //        if (Ogro.Id >= min && Ogro.Id <= max)
        //        {
        //            _context.Remove(Ogro);
        //            _context.SaveChanges();
        //        }
        //    }
        //    return Ok();
}