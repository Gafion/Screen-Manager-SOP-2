﻿namespace Screen_Manager_SOP_2
{
    public class UserRepository
    {
        private readonly List<User> users = [];

        public UserRepository()
        {
            AddUser("Christian", "Colberg", "kroll94@gmail.com", "60620466", "Hedelyparken 84 st th", "Dev");
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void AddUser(string firstName, string lastName, string emailAddress, string phoneNumber, string address, string title)
        {
            int newId = users.Count != 0 ? users.Max(u => u.Id) + 1 : 1;
            User newUser = new()
            {
                Id = newId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                Address = address,
                Title = title,
            };

            users.Add(newUser);
        }

        public bool RemoveUser(int id)
        {
            int removedCount = users.RemoveAll(u => u.Id == id);
            return removedCount > 0;
        }

    }
}
