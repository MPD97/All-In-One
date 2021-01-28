using AOI_Core.Entites;
using Bogus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using static AOI_Core.Entites.Person;

namespace AOI_Infrastructure.Npgsql.Seed
{
    public class PersonGenerator
    {
        private const int SAVE_AMOUNT = 10000;
        private readonly ApplicationContext _context;
        private ILogger<PersonGenerator> _logger;

        public PersonGenerator(ApplicationContext context, ILogger<PersonGenerator> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Generate(int amount = 100000)
        {
            var set = _context.Set<AOI_Core.Entites.Person>();
            _logger.LogInformation("PersonGenerator started. Amount: {AmountGenerate}", amount);

            var generator = new Faker<AOI_Core.Entites.Person>()
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth)
                .RuleFor(x => x.Gender, x => (GenderType)x.Person.Gender)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth)
                .RuleFor(x => x.Phone, x => x.Person.Phone);

            for (int i = 0; i < amount; i++)
            {
                var person = generator.Generate();

                set.Add(person);
                if (i % SAVE_AMOUNT == 0)
                {
                    _logger.LogInformation("Saving next {SAVE_AMOUNT} entities. Current index {index} of {AmountGenerate}.", SAVE_AMOUNT, i, amount);
                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();
            _logger.LogInformation("PersonGenerator ended. Amount: {AmountGenerate}", amount);
        }
    }
}
