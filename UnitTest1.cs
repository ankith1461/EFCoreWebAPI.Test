using System;
using Xunit;
using WebApiCoreEdx.Controllers;
using WebApiCoreEdx.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EFCoreWebAPI.Test
{
    /* Sample Test Class */
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1 , 0);
        }
    }

    /* Functional Test Case for Films Controller */
    public class FilmsControllerFunctionTest
    {
        [Fact]
        public void GetFilmByIdSmokeTest()
        {
            var controller = new FilmsController();
            var result = controller.GetFilm(10);
            
            Assert.Equal(result.Film_ID, 10);
            Assert.Equal(result.Title, "ALADDIN CALENDAR");
            Assert.Equal(result.Release_Year, 2006);
        }
    }

    /* End to End Test case for Films Controller */
    public class FilmsControllerEndToEndTest
    {
        [Fact]
        public async void GetFilmByIdSmokeTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpClient.GetAsync("api/Films/10");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Film film = JsonConvert.DeserializeObject<Film>(jsonString);
                Assert.NotNull(film);
                Assert.Equal(film.Film_ID, 10);
                Assert.Equal(film.Title, "ALADDIN CALENDAR");
                Assert.Equal(film.Release_Year, 2006);
            }
        }
    }
}
