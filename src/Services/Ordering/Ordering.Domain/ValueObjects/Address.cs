using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddresLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCone { get; } = default!;

        protected Address() { }

        private Address(string firstName, string lastName, string emailAddress, string addresLine, string country, string state, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddresLine = addresLine;
            Country = country;
            State = state;
            ZipCone = zipcode;
        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addresLine, string country, string state, string zipcode)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addresLine);

            return new Address(firstName, lastName, emailAddress, addresLine, country, state, zipcode);
        }
    }
}
