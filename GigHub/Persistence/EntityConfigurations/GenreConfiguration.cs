using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {

        public GenreConfiguration()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}