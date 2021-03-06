﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LastBox.Models;

namespace LastBox.Controllers
{
    public class SurveyModelsController : Controller
    {
        private RegisteredUserDbContext db = new RegisteredUserDbContext();
        BoxesController bc;
        public ActionResult ViewBoxRecommendation(Box box)
        {
            return View();
            //db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);

        }

        [HttpGet]
        public ActionResult GoToSurvey()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoToSurvey([Bind(Include = "ID,gender,age,Money,alcohol,presentable, books, candles, candy, clothes, coffee, fitness, games, movies, music, sports, active, candle, entertainment, foodORdrink, appearance")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {

                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();
                return RedirectToAction("Index", surveyModel);
            }

            return View("Index", surveyModel);
        }

        // GET: SurveyModels
        public ActionResult Index()
        {
            return View(db.SurveyResponses.ToList());
        }

        // GET: SurveyModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // GET: SurveyModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.SurveyResponses.Add(surveyModel);
                db.SaveChanges();

                return RedirectToAction("GetCurrentSurveyResults", surveyModel);  //change "Index" to "GetCurrentSurveyResults" and add ,surveyModel
            }

            return View(surveyModel);
        }

        // GET: SurveyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // POST: SurveyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetSurveyResults"); //change from index to results page
            }
            return View(surveyModel);
        }

        // GET: SurveyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            if (surveyModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyModel);
        }

        // POST: SurveyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyModel surveyModel = db.SurveyResponses.Find(id);
            db.SurveyResponses.Remove(surveyModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult GetCurrentSurveyResults(SurveyModel sm)
        {
            int age = sm.Age;
            int money = sm.maxMoney;
            int active = sm.Active;
            int candle = sm.Candle;
            int entertainment = sm.Entertainment;
            int foodORdrink = sm.FoodORdrink;
            int looks = sm.Appearance;
            int gender = sm.Gender;
            bool alcohol = sm.Alcohol;
            bool presentable = sm.Presentable;
            bool books = sm.Books;
            bool candles = sm.Candles;
            bool candy = sm.Candy;
            bool clothes = sm.Clothes;
            bool coffee = sm.Coffee;
            bool fitness = sm.Fitness;
            bool games = sm.Games;
            bool movies = sm.Movies;
            bool music = sm.Music;
            bool sports = sm.Sports;
            Box box = new Box();
            Box ofBeer = new Box();
            BoxContents Highlife = new BoxContents("Highlife");
            BoxContents PBR = new BoxContents("PBR");
            BoxContents Corona = new BoxContents("Corona");
            Box ofWine = new Box();
            BoxContents Moscato = new BoxContents("Moscato");
            BoxContents Chardonnay = new BoxContents("Chardonnay");
            Box ofCandles = new Box();
            BoxContents Aromatherapy = new BoxContents("Aromatherapy Candle");
            BoxContents Fruit = new BoxContents("Fruit-scented Candle");
            BoxContents Flower = new BoxContents("Flower=scented Candle");
            Box ofFitness = new Box();
            BoxContents Shake = new BoxContents("Shake Weight");
            Box ofGames = new Box();
            BoxContents Scrabble = new BoxContents("Scrabble");
            BoxContents Yahtzee = new BoxContents("Yahtzee");
            Box ofMovies = new Box();
            BoxContents DieHard = new BoxContents("Die Hard");
            BoxContents BigGreen = new BoxContents("The Big Green");
            BoxContents PT = new BoxContents("Pootie Tang");
            Box ofMusic = new Box();
            BoxContents CW = new BoxContents("Chumbawamba- Tubthumper");
            Box ofCandy = new Box();
            BoxContents Nerds = new BoxContents("Nerds");
            BoxContents MM = new BoxContents("M&Ms");
            BoxContents Skittles = new BoxContents("Skittles");
            Box ofCoffee = new Box();
            BoxContents Beans = new BoxContents("Generic Coffee Beans");
            Box ofAppearanceM = new Box();
            BoxContents Razor = new BoxContents("Shaving kit");
            Box ofAppearanceF = new Box();
            BoxContents Lipstick = new BoxContents("Lipstick");
            BoxContents Mascara = new BoxContents("Mascara");



            if (age > 1 && alcohol == true && gender == 1 && money == 3)
            {

                ofBeer.Name = "Beer Box";
                ofBeer.Category = "Alcohol";
                ofBeer.Description = "This box contains various beers in it.";
                ofBeer.Cost = 30;
                ofBeer.Contents = new List<BoxContents>();

                ofBeer.Contents.Add(Highlife);
                ofBeer.Contents.Add(PBR);
                ofBeer.Contents.Add(Corona);

                box = ofBeer;

            }
            else if (age > 1 && alcohol == true && gender == 2 && money == 3)
            {
                ofWine.Name = "Wine Box";
                ofWine.Category = "Alcohol";
                ofWine.Description = "This box contains two bottles of wine";
                ofWine.Cost = 30;

                ofWine.Contents = new List<BoxContents>();
                ofWine.Contents.Add(Moscato);
                ofWine.Contents.Add(Chardonnay);

                box = ofWine;

            }
            else if (candle > 1 && candles == true)
            {
                ofCandles.Name = "Candle Box";
                ofCandles.Category = "Candles";
                ofCandles.Description = "This box contains three candles.";
                ofCandles.Cost = 15;
                ofCandles.Contents = new List<BoxContents>();
                ofCandles.Contents.Add(Aromatherapy);
                ofCandles.Contents.Add(Flower);
                ofCandles.Contents.Add(Fruit);
                box = ofCandles;

            }
            else if (active > 1 && fitness == true && money > 1)
            {

                ofFitness.Name = "Fitness Box";
                ofFitness.Category = "Fitness";
                ofFitness.Description = "This box contains a fitness item.";
                ofFitness.Cost = 20;
                ofFitness.Contents = new List<BoxContents>();

                ofFitness.Contents.Add(Shake);
                box = ofFitness;

            }
            else if (entertainment > 1 && games == true)
            {
                ofGames.Name = "Game Box";
                ofGames.Category = "Entertainment";
                ofGames.Description = "This box contains a game.";
                ofGames.Cost = 10;
                ofGames.Contents = new List<BoxContents>();
                ofGames.Contents.Add(Scrabble);
                ofGames.Contents.Add(Yahtzee);
                box = ofGames;

            }
            else if (entertainment > 1 && movies == true)
            {
                ofMovies.Name = "Movie Box";
                ofMovies.Category = "Entertainment";
                ofMovies.Description = "This box contains three movies";
                ofMovies.Cost = 15;
                ofMovies.Contents = new List<BoxContents>();
                ofMovies.Contents.Add(DieHard);
                ofMovies.Contents.Add(BigGreen);
                ofMovies.Contents.Add(PT);
                box = ofMovies;
            }
            else if (entertainment > 1 && music == true)
            {
                ofMusic.Name = "Music Box";
                ofMusic.Category = "Entertainment";
                ofMusic.Description = "This box contains a CD";
                ofMusic.Cost = 5;
                ofMusic.Contents = new List<BoxContents>();
                ofMusic.Contents.Add(CW);
                box = ofMusic;
            }
            else if (foodORdrink > 1 && candy == true)
            {
                ofCandy.Name = "Candy Box";
                ofCandy.Category = "Food/Drink";
                ofCandy.Description = "This box contains candy";
                ofCandy.Cost = 7;
                ofCandy.Contents = new List<BoxContents>();
                ofCandy.Contents.Add(Nerds);
                ofCandy.Contents.Add(MM);
                ofCandy.Contents.Add(Skittles);
                box = ofCandy;
            }
            else if (foodORdrink > 1 && coffee == true)
            {
                ofCoffee.Name = "Coffee Box";
                ofCoffee.Category = "Food/Drink";
                ofCoffee.Description = "This box contains a bag of coffee beans.";
                ofCoffee.Cost = 15;
                ofCoffee.Contents = new List<BoxContents>();
                ofCoffee.Contents.Add(Beans);
                box = ofCoffee;
            }
            else if (looks > 1 && presentable == true && gender == 1)
            {
                ofAppearanceM.Name = "Manscaping Box";
                ofAppearanceM.Category = "Grooming";
                ofAppearanceM.Description = "This box contains shaving supplies.";
                ofAppearanceM.Cost = 10;
                ofAppearanceM.Contents = new List<BoxContents>();
                ofAppearanceM.Contents.Add(Razor);
                box = ofAppearanceM;
            }
            else if (looks > 1 && presentable == true && gender == 2)
            {
                ofAppearanceF.Name = "Makeup Box";
                ofAppearanceF.Category = "Grooming";
                ofAppearanceF.Description = "This box contains makeup stuff";
                ofAppearanceF.Cost = 15;
                ofAppearanceF.Contents = new List<BoxContents>();
                ofAppearanceF.Contents.Add(Lipstick);
                ofAppearanceF.Contents.Add(Mascara);
                box = ofAppearanceF;
            }
            else
            {
                List<Box> Boxes = new List<Box>();
                Boxes.Add(ofCandles);
                Boxes.Add(ofCandy);
                Boxes.Add(ofGames);
                Boxes.Add(ofMusic);
                Boxes.Add(ofMovies);

                Random rnd = new Random();
                int r = rnd.Next(0,Boxes.Count);

                box = Boxes[r];

            }

            //db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);
            ViewBag.BoxName = box.Name;
            ViewBag.BoxDescription = box.Description;
            ViewBag.BoxCategory = box.Category;
            ViewBag.BoxCost = box.Cost;
            Session["SubBox"] = box.Name;
            Session["SubPrice"] = box.Cost;
            return ViewBoxRecommendation(box);
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using LastBox.Models;

//namespace LastBox.Controllers
//{
//    public class SurveyModelsController : Controller
//    {
//        private RegisteredUserDbContext db = new RegisteredUserDbContext();
//        BoxesController bc;
//        public ActionResult ViewBoxRecommendation(Box box)
//        {  
//            return View();
//             //db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);

//        }

//        [HttpGet]
//        public ActionResult GoToSurvey()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult GoToSurvey([Bind(Include = "ID,gender,age,Money,alcohol,presentable, books, candles, candy, clothes, coffee, fitness, games, movies, music, sports, active, candle, entertainment, foodORdrink, appearance")] SurveyModel surveyModel)
//        {
//            if (ModelState.IsValid)
//            {

//                db.SurveyResponses.Add(surveyModel);
//                db.SaveChanges();
//                return RedirectToAction("Index", surveyModel);
//            }

//            return View("Index", surveyModel);
//        }

//        // GET: SurveyModels
//        public ActionResult Index()
//        {
//            return View(db.SurveyResponses.ToList());
//        }

//        // GET: SurveyModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SurveyModel surveyModel = db.SurveyResponses.Find(id);
//            if (surveyModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(surveyModel);
//        }

//        // GET: SurveyModels/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: SurveyModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.SurveyResponses.Add(surveyModel);
//                db.SaveChanges();

//                return RedirectToAction("GetCurrentSurveyResults", surveyModel);  //change "Index" to "GetCurrentSurveyResults" and add ,surveyModel
//            }

//            return View(surveyModel);
//        }

//        // GET: SurveyModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SurveyModel surveyModel = db.SurveyResponses.Find(id);
//            if (surveyModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(surveyModel);
//        }

//        // POST: SurveyModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,gender,age,Money,alcohol,presentable,books,candles,candy,clothes,coffee,fitness,games,movies,music,sports,active,candle,entertainment,foodORdrink,looks")] SurveyModel surveyModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(surveyModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("GetSurveyResults"); //change from index to results page
//            }
//            return View(surveyModel);
//        }

//        // GET: SurveyModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            SurveyModel surveyModel = db.SurveyResponses.Find(id);
//            if (surveyModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(surveyModel);
//        }

//        // POST: SurveyModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            SurveyModel surveyModel = db.SurveyResponses.Find(id);
//            db.SurveyResponses.Remove(surveyModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        public ActionResult GetCurrentSurveyResults(SurveyModel sm)
//        {
//            int age = sm.Age;
//            int money = sm.Money;
//            int active = sm.Active;
//            int candle = sm.Candle;
//            int entertainment = sm.Entertainment;
//            int foodORdrink = sm.foodORdrink;
//            int looks = sm.Looks;
//            int gender = sm.Gender;
//            bool alcohol = sm.Alcohol;
//            bool appearance = sm.Appearance;
//            bool books = sm.Books;
//            bool candles = sm.Candles;
//            bool candy = sm.Candy;
//            bool clothes = sm.Clothes;
//            bool coffee = sm.Coffee;
//            bool fitness = sm.Fitness;
//            bool games = sm.Games;
//            bool movies = sm.Movies;
//            bool music = sm.Music;
//            bool sports = sm.Sports;
//            Box box = new Box();
//            Box ofBeer = new Box();
//            BoxContents Highlife = new BoxContents("Highlife");
//            BoxContents PBR = new BoxContents("PBR");
//            BoxContents Corona = new BoxContents("Corona");
//            if (age > 1 && alcohol == true && gender == 1)
//            {

//                ofBeer.Name = "Beer Box";
//                ofBeer.Category = "alcohol";
//                ofBeer.Description = "This box contains various beers in it.";
//                ofBeer.Cost = 30;
//                Highlife.Name = "High Life";
//                Highlife.Name = "PBR";
//                Corona.Name = "Corona";
//                ofBeer.Contents = new List<BoxContents>();

//                ofBeer.Contents.Add(Highlife);
//                ofBeer.Contents.Add(PBR);
//                ofBeer.Contents.Add(Corona);
//                box = ofBeer;





//}
//    else if (age > 1 && alcohol == true && gender == 2)
//    {
//        Box ofWine = new Box();
//        ofWine.Name = "Wine Box";
//        ofWine.Category = "alcohol";
//        ofWine.Description = "This box contains two bottles of wine";
//        ofWine.Cost = 30;
//
//        BoxContents Moscato = new BoxContents();
//        BoxContents Chardonnay = new BoxContents();
//
//        Moscato.Name = "Moscato";
//        Chardonnay.Name = "Chardonnay";
//
//        ofWine.Contents.Add(Moscato);
//        ofWine.Contents.Add(Chardonnay);
//        box = ofWine;
//
//    }
//    else if (candle > 2 && candles == true)
//    {
//        Box ofCandles = new Box();
//        ofCandles.Name = "Candle Box";
//        ofCandles.Category = "candles";
//        ofCandles.Description = "This box contains three candles.";
//        ofCandles.Cost = 15;
//
//        BoxContents Candle1 = new BoxContents();
//        BoxContents Candle2 = new BoxContents();
//        BoxContents Candle3 = new BoxContents();
//
//        Candle1.Name = "Aromatherapy Candle";
//        Candle2.Name = "Flower Candle";
//        Candle3.Name = "Fruit Candle";
//
//        ofCandles.Contents.Add(Candle1);
//        ofCandles.Contents.Add(Candle2);
//        ofCandles.Contents.Add(Candle3);
//        box = ofCandles;
//
//    }
//    else if(active > 2 && fitness == true)
//    {
//        Box ofFitness = new Box();
//        ofFitness.Name = "Fitness Box";
//        ofFitness.Category = "fitness";
//        ofFitness.Description = "This box contains a fitness item.";
//        ofFitness.Cost = 35;
//        BoxContents SW = new BoxContents();
//        SW.Name = "Shake weight";
//        ofFitness.Contents.Add(SW);
//        box = ofFitness;
//
//    }
//    else if(entertainment > 2 && games == true)
//    {
//        Box ofGames = new Box();
//        ofGames.Name = "Game Box";
//        ofGames.Category = "games";
//        ofGames.Description = "This box contains a game.";
//        ofGames.Cost = 10;
//        BoxContents game = new BoxContents();
//        game.Name = "Scrabble";
//        ofGames.Contents.Add(game);
//        box = ofGames;
//
//    }
//    else if (entertainment > 2 && movies == true)
//    {
//        Box ofMovies = new Box();
//        ofMovies.Name = "Movie Box";
//        ofMovies.Description = "This box contains three movies";
//        ofMovies.Cost = 15;
//        BoxContents Movie1 = new BoxContents();
//        BoxContents Movie2 = new BoxContents();
//        BoxContents Movie3 = new BoxContents();
//        Movie1.Name = "Die Hard";
//        Movie2.Name = "The Big Green";
//        Movie3.Name = "Pootie Tang";
//        ofMovies.Contents.Add(Movie1);
//        ofMovies.Contents.Add(Movie2);
//        ofMovies.Contents.Add(Movie3);
//        box = ofMovies;
//    }
//    else if (entertainment > 2 && music == true)
//    {
//        Box ofMusic = new Box();
//        ofMusic.Name = "Music Box";
//        ofMusic.Description = "This box contains a CD";
//        ofMusic.Cost = 5;
//        BoxContents CD = new BoxContents();
//        CD.Name = "Chumbawamba- Tubthumper";
//        ofMusic.Contents.Add(CD);
//        box = ofMusic;
//    }
//    else if(foodORdrink > 2 && candy == true)
//    {
//        Box ofCandy = new Box();
//        ofCandy.Name = "Candy Box";
//        ofCandy.Description = "This box contains candy";
//        ofCandy.Cost = 7;
//        BoxContents candy3 = new BoxContents();
//        BoxContents candy1 = new BoxContents();
//        BoxContents candy2 = new BoxContents();
//        candy1.Name = "Nerds";
//        candy2.Name = "M&Ms";
//        candy3.Name = "Skittles";
//
//        ofCandy.Contents.Add(candy1);
//        ofCandy.Contents.Add(candy2);
//        ofCandy.Contents.Add(candy3);
//        box = ofCandy;
//
//
//    }
//    else if(foodORdrink > 2 && coffee == true)
//    {
//        Box ofCoffee = new Box();
//        ofCoffee.Name = "Coffee Box";
//        ofCoffee.Description = "This box contains a bag of coffee beans.";
//        ofCoffee.Cost = 15;
//        BoxContents beans = new BoxContents();
//        beans.Name = "Generic Coffee Beans";
//
//        ofCoffee.Contents.Add(beans);
//        box = ofCoffee;
//    }
//    else if (looks > 2 && appearance == true && gender == 1)
//    {
//        Box ofAppearanceM = new Box();
//        ofAppearanceM.Name = "Manscaping Box";
//        ofAppearanceM.Description = "This box contains shaving supplies.";
//        ofAppearanceM.Cost = 10;
//        BoxContents razor = new BoxContents();
//        razor.Name = "Shaving kit";
//        ofAppearanceM.Contents.Add(razor);
//        box = ofAppearanceM;
//    }
//    else if (looks > 2 && appearance == true && gender == 2)
//    {
//        Box ofAppearanceF = new Box();
//        ofAppearanceF.Name = "Makeup Box";
//        ofAppearanceF.Description = "This box contains makeup stuff";
//        ofAppearanceF.Cost = 15;
//        BoxContents makeup = new BoxContents();
//        BoxContents other = new BoxContents();
//        makeup.Name = "Lipstick";
//        other.Name = "Mascara";
//
//        ofAppearanceF.Contents.Add(makeup);
//        ofAppearanceF.Contents.Add(other);
//        box = ofAppearanceF;
//    }

//db.SurveyResponses.Select(x => x).Where(x => x.Age < 21);
//            ViewBag.BoxName = box.Name;
//            ViewBag.BoxDescription = box.Description;
//            ViewBag.BoxCost = box.Cost;

//            return ViewBoxRecommendation(box);
//        }
//    }
//}
