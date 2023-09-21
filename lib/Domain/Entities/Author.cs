﻿namespace lib.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
