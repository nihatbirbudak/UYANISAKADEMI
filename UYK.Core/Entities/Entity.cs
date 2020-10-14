﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.Core.Entities
{
    public abstract class Entity<T> : EntityBase, IEntity<T> where T : struct
    {
        public virtual T Id { get; set; }
    }
}
