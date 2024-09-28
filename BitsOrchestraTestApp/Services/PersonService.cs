using BitsOrchestraTestApp.Data;
using BitsOrchestraTestApp.Dtos;
using BitsOrchestraTestApp.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BitsOrchestraTestApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task UploadPersonsFromCsvAsync(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<PersonUploadDto>().ToList();

            var persons = new List<Person>();

            foreach (var record in records) 
            {
                persons.Add(new Person()
                {
                    Name = record.Name,
                    DateOfBirth = record.DateOfBirth,
                    Married = record.Married,
                    Phone = record.Phone,
                    Salary = record.Salary,
                });
            }

            await _context.Persons.AddRangeAsync(persons);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PersonDto>> GetAllPersonsAsync()
        {
            return await _context.Persons
                .Select(p => new PersonDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    DateOfBirth = p.DateOfBirth,
                    Married = p.Married,
                    Phone = p.Phone,
                    Salary = p.Salary
                })
                .ToListAsync() ?? new List<PersonDto>();
        }

        public async Task EditPersonAsync(PersonDto personDto)
        {
            var personToUpdate = await _context.Persons.FindAsync(personDto.Id);

            if (personToUpdate != null)
            {
                personToUpdate.Name = personDto.Name;
                personToUpdate.DateOfBirth = personDto.DateOfBirth;
                personToUpdate.Married = personDto.Married;
                personToUpdate.Phone = personDto.Phone;
                personToUpdate.Salary = personDto.Salary;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
