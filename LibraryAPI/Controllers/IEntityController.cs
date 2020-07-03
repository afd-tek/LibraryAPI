﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    public interface IEntityController<T> where T : class, new()
    {
        IActionResult Add(T entity);

        IActionResult Get(int id);

        IActionResult Update(T entity);

        IActionResult GetAll();

        IActionResult Remove(int id);
    }
}
