using Xunit;

using BasicAPI;
using BasicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EventUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetReturnOk()
        {
            //Arrange - ארגון הנתונים הנדרשים להפעלת הפונקציה הנבדקת

            //Act - הפעלת הפונקציה הנבדקת
            var controller = new EventsController();
            var result = controller.Get();
            //Asser - הכרזה מה התוצאה הרצויה
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnOk()
        {
            var controller = new EventsController();

            //Arrange - ארגון הנתונים הנדרשים להפעלת הפונקציה הנבדקת
            var id = 1;

            //Act - הפעלת הפונקציה הנבדקת
            var result = controller.GetById(id);

            //Asser - הכרזה מה התוצאה הרצויה
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            var controller = new EventsController();
            var id = 8;
            var result = controller.GetById(id);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Post_ReturnOk()
        {
            var controller = new EventsController();
            Event e = new Event { Title = "I want to finish this project", Start = new DateOnly(2023, 11, 26) };
            var result = controller.Post(e);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Put_ReturnOk()
        {
            var controller = new EventsController();
            var id = 2;
            Event e = new Event { Title = "I almost finish this project", Start = new DateOnly(2023, 11, 26) };
            var result = controller.Put(id, e);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Put_ReturnNotFound()
        {
            var controller = new EventsController();
            var id = 800;
            Event e = new Event { Title = "I  finish, yayy!!!!", Start = new DateOnly(2023, 11, 26) };
            var result = controller.Put(id, e);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Delete_ReturnOk()
        {
            var controller = new EventsController();
            var id = 1;
            var result = controller.Delete(id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_ReturnNotFound()
        {
            var controller = new EventsController();
            var id = 1000;
            var result = controller.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}