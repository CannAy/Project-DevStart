﻿using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Service.Services
{
    public class LessonService : ILessonService
    {
        public Task Add(LessonViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<LessonViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LessonViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}