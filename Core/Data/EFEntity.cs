using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Interfaces;

namespace Core.Data
{
    [Serializable]
    public class EFEntity<T> : IEntity<T> where T : struct
    {
        /// <summary>
        /// Gets or sets ID of object
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }

    }
}

