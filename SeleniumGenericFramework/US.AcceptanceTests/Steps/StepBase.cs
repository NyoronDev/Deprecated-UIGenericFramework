using System.Collections.Generic;
using System.IO;
using System.Linq;
using DF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The step base.
    /// </summary>
    [TestClass]
    public class StepBase : TechTalk.SpecFlow.Steps
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        private static TestContext context;

        private IEnumerable<UserLogin> loginUsers;

        private string usersFile = @"TestData\Users.json";

        public TestContext CurrentTestContext => context;

        /// <summary>
        /// Gets the login users.
        /// </summary>
        public IEnumerable<UserLogin> LoginUsers
        {
            get
            {
                if (loginUsers == null)
                {
                    loginUsers = LoadUsers();
                }

                return loginUsers;
            }
        }

        /// <summary>
        /// Assemblies the initialize.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            if (context == null)
            {
                context = testContext;
            }
        }

        /// <summary>
        /// Gets the login user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The <see cref="UserLogin"/>
        /// </returns>
        public UserLogin GetLoginUser(string user)
        {
            if (loginUsers == null)
            {
                loginUsers = LoadUsers();
            }

            return this.loginUsers.FirstOrDefault(i => i.UserId == user);
        }

        private IEnumerable<UserLogin> LoadUsers()
        {
            using (var file = File.OpenText(usersFile))
            {
                var serializer = new JsonSerializer();
                return (List<UserLogin>)serializer.Deserialize(file, typeof(List<UserLogin>));
            }
        }
    }
}