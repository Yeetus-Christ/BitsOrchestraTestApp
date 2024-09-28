using BitsOrchestraTestApp.Data;
using BitsOrchestraTestApp.Dtos;
using BitsOrchestraTestApp.Models;
using BitsOrchestraTestApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace UnitTests
{
    public class PersonServiceTests : IDisposable
    {
        private readonly AppDbContext _context;

        public PersonServiceTests()
        {
            _context = CreateDbContext();
        }

        [Fact]
        public async Task GetAllPersonsAsync_ReturnsAllPersons()
        {
            await ClearDatabaseAsync();

            // Arrange
            _context.Persons.Add(new Person { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Married = true, Phone = "123-456-7890", Salary = 50000 });
            _context.Persons.Add(new Person { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1992, 2, 2), Married = false, Phone = "987-654-3210", Salary = 60000 });
            await _context.SaveChangesAsync();

            var service = new PersonService(_context);

            // Act
            var result = await service.GetAllPersonsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("John Doe", result[0].Name);
            Assert.Equal("Jane Smith", result[1].Name);
        }

        [Fact]
        public async Task EditPersonAsync_UpdatesExistingPerson()
        {
            await ClearDatabaseAsync();

            // Arrange
            var person = new Person { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Married = true, Phone = "123-456-7890", Salary = 50000 };
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            var service = new PersonService(_context);
            var updatedPersonDto = new PersonDto { Id = 1, Name = "John Updated", DateOfBirth = new DateTime(1991, 1, 1), Married = false, Phone = "321-654-0987", Salary = 55000 };

            // Act
            await service.EditPersonAsync(updatedPersonDto);

            // Assert
            var updatedPerson = await _context.Persons.FindAsync(1);
            Assert.Equal("John Updated", updatedPerson.Name);
            Assert.False(updatedPerson.Married);
            Assert.Equal("321-654-0987", updatedPerson.Phone);
            Assert.Equal(55000, updatedPerson.Salary);
        }

        [Fact]
        public async Task DeletePersonAsync_RemovesPerson()
        {
            await ClearDatabaseAsync();

            // Arrange
            _context.Persons.Add(new Person { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Married = true, Phone = "123-456-7890", Salary = 50000 });
            await _context.SaveChangesAsync();

            var service = new PersonService(_context);

            // Act
            await service.DeletePersonAsync(1);

            // Assert
            var deletedPerson = await _context.Persons.FindAsync(1);
            Assert.Null(deletedPerson);
        }

        [Fact]
        public async Task UploadPersonsFromCsvAsync_AddsPersonsToDatabase()
        {
            await ClearDatabaseAsync();

            // Arrange
            var service = new PersonService(_context);

            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            var existingCsvFilePath = Path.Combine(projectRoot, "TestData", "MockDataValid.csv");

            using var stream = new FileStream(existingCsvFilePath, FileMode.Open);

            // Act
            await service.UploadPersonsFromCsvAsync(stream);

            // Assert
            Assert.True(await _context.Persons.AnyAsync());
            Assert.Equal(10, await _context.Persons.CountAsync());
        }

        [Fact]
        public async Task UploadPersonsFromCsvAsync_InvalidData_ThrowsException()
        {
            await ClearDatabaseAsync();

            // Arrange
            var service = new PersonService(_context);

            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            var existingCsvFilePath = Path.Combine(projectRoot, "TestData", "MockDataInvalid.csv");

            using var stream = new FileStream(existingCsvFilePath, FileMode.Open);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => service.UploadPersonsFromCsvAsync(stream));
        }

        private AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            return new AppDbContext(options);
        }

        private async Task ClearDatabaseAsync()
        {
            var persons = await _context.Persons.ToListAsync();
            _context.Persons.RemoveRange(persons);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}