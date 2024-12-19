﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Genero_BLL
    {
        //Create
        public static string Insert_Genero(GeneroPelicula_VO genero)
        {
            return Genero_DAL.Insert_Genero(genero);
        }

        //Read
        public static List<GeneroPelicula_VO> GetGenero(params object[] parametros)
        {
            return Genero_DAL.GetGenero(parametros);
        }

        //Delete
        public static string Delete_Genero(int id)
        {
            return Genero_DAL.DeleteGenero(id);
        }
    }
}
