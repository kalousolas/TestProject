using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestCore.Services;


namespace TestProject.Controllers
{
    public class FlightController : AsyncController
    {
        private readonly FlightApiTestService service = new FlightApiTestService();

        public async Task<ActionResult> Index()
        {
            string searchData = "";
           // searchData = await service.GetSearchDataAsync();
            
           /* for (int i = 0; i < 3; i++)
            {
                await Task.Factory.StartNew(async () =>
                {
                    searchData = await service.GetSearchData();
                });
            }   
            */
          //  string searchData = await service.GetSearchData();
           // bool loadtest = await service.LoadTest();
            
          //  Task<string[]> searchData = service.LoadTest();
            
          // Task<string> task = service.GetSearchData();
            //List<Task> tasks = new List<Task>();
            //for (int i = 0; i < 3; i++)
            //{
            //    tasks.Add(service.GetSearchData());
            //}
            //await Task.WhenAll(t1,t2);
          /*  foreach (var task in tasks)
            {
                await Task.WhenAll(task);
            }
           * */
            //Parallel.ForEach(tasks, i => service.GetSearchData().Wait());
            

               /* await Task.Factory.StartNew(async () =>
                {
                    searchData = await service.GetSearchData();
                });
                
           
            */
           

/*
            List<Task<string>> tasks = new List<Task<string>>();

                for (int i = 0; i < 3; i++)
                {

                    tasks.Add((Task<string>) await Task.Factory.StartNew(async () =>
                                                                       {
                                                                           searchData = await service.GetSearchData();
                                                                       }));
                }
                Task.WaitAll(tasks.ToArray());
               */
            return View("index", searchData);
        }
    }
}
