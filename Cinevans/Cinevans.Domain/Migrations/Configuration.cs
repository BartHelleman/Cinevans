namespace Cinevans.Domain.Migrations {
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Diagnostics.CodeAnalysis;
    using Concrete;

    [ExcludeFromCodeCoverage]
    internal sealed class Configuration:DbMigrationsConfiguration<Cinevans.Domain.Concrete.EFDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDbContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            /*
                new Genre { GenreId = 1, Name = "Action" },
                new Genre { GenreId = 2, Name = "Adventure" },
                new Genre { GenreId = 3, Name = "Thriller" },
                //new Genre { GenreId = 4, Name = "Fantasy" },
                //new Genre { GenreId = 5, Name = "Animation" },
                //new Genre { GenreId = 6, Name = "Family" },
                //new Genre { GenreId = 7, Name = "Comedy" },
                //new Genre { GenreId = 8, Name = "Romance" },
                //new Genre { GenreId = 9, Name = "Horror" }
            */

            List<NewsLetter> newsLetterList = new List<NewsLetter>
            {
                new NewsLetter { NewsLetterId = 1, Email = "ikjman@hotmail.com" },
                new NewsLetter { NewsLetterId = 2, Email = "ikjmanxbox@hotmail.com" }
            };


            Genre actionGenre = new Genre { GenreId = 1, Name = "Action" };
            Genre adventureGenre = new Genre { GenreId = 2, Name = "Adventure" };
            Genre thrillerGenre = new Genre { GenreId = 3, Name = "Thriller" };
            Genre fantasyGenre = new Genre { GenreId = 4, Name = "Fantasy" };
            Genre animationGenre = new Genre { GenreId = 5, Name = "Animation" };
            Genre familyGenre = new Genre { GenreId = 6, Name = "Family" };
            Genre comedyGenre = new Genre { GenreId = 7, Name = "Comedy" };
            Genre romanceGenre = new Genre { GenreId = 8, Name = "Romance" };
            Genre horrorGenre = new Genre { GenreId = 9, Name = "Horror" };

            List<Genre> genreList = new List<Genre>
            {
                actionGenre,
                adventureGenre,
                thrillerGenre
            };

            List<Genre> genreList1 = new List<Genre>
            {
                comedyGenre,
                romanceGenre,
                horrorGenre

            };

            List<Genre> genreList2 = new List<Genre>
            {
                animationGenre,
                familyGenre,
                comedyGenre

            };

            List<Genre> genreList3 = new List<Genre>
            {
              thrillerGenre,
              fantasyGenre,
              animationGenre

            };

            Rate normalRate = new Rate { RateId = 1, Name = "Normaal",EnglishName = "Normal", Price = 8.50 };
            Rate childRate = new Rate { RateId = 2, Name = "Kinderkaartje", EnglishName = "Childticket", Price = 7.00 };
            Rate studentRate = new Rate { RateId = 3, Name = "Studentenkaartje", EnglishName = "Studentticket", Price = 7.00 };
            Rate seniorRate = new Rate { RateId = 4, Name = "Seniorenkaartje", EnglishName = "Seniorticket", Price = 7.00 };
            Rate popcornRate = new Rate { RateId = 5, Name = "Popcornarrangement", EnglishName = "Popcornticket", Price = 10.00 };
            Rate ladiesNightRate = new Rate { RateId = 6, Name = "Ladiesnight", EnglishName = "Ladiesnight", Price = 10.00 };

            List<Rate> rateListWithoutChild = new List<Rate>
            {
                normalRate,
                studentRate,
                seniorRate,
                popcornRate,

            };
            List<Rate> rateListWithLadies = new List<Rate>
            {
                normalRate,
                studentRate,
                seniorRate,
                popcornRate,
                ladiesNightRate

            };


            List<Rate> ratesList = new List<Rate>
            {
                normalRate,
                childRate,
                studentRate,
                seniorRate,
                popcornRate
            };

            List<Cast> castList = new List<Cast>
            {
                new Cast { CastId = 1, Name = "Rico Kolditz", Age = 55},
                new Cast { CastId = 2, Name = "Ruben Visser", Age = 44 },
                new Cast { CastId = 3, Name = "Bart Visser", Age = 33 }

            };

            List<Director> directorList = new List<Director>
            {
                new Director { DirectorId = 1, Name = "Nick", Age = 20},
                new Director { DirectorId = 2, Name = "Jan", Age = 20 }

            };



            var movieList = new List<Movie>
            {
                new Movie {
                    MovieId = 1,
                    Titel = "Deadpool",
                    Duration = 108,
                    Age = 16,
                    MovieImage = "http://ia.media-imdb.com/images/M/MV5BMjQyODg5Njc4N15BMl5BanBnXkFtZTgwMzExMjE3NzE@._V1_SX640_SY720_.jpg",
                    Description = "Deadpool vertelt het verhaal van Wade Wilson, een voormalig Special Forces-agent die huurmoordenaar werd. Nadat hij deelneemt aan een experiment dat hem de mogelijkheid geeft om sneller te genezen, transformeert hij in Deadpool. Gewapend met een pak nieuwe mogelijkheden gaat hij op zoek naar de man die bijna zijn leven verwoestte.",
                    EnglishDescription = "A former Special Forces operative turned mercenary is subjected to a rogue experiment that leaves him with accelerated healing powers, adopting the alter ego Deadpool.",
                    is3D = false,
                    ReleaseDate = DateTime.Parse("2016-03-03"),
                    Rates = rateListWithoutChild,
                    Genres = genreList,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/gtTfd6tISfw",
                    ImdbLink = "http://www.imdb.com/title/tt1431045/",
                    UserReview = 3
                },
                new Movie {
                    MovieId = 2,
                    Titel = "The Revenant",
                    Duration = 156,
                    Age = 16,
                    MovieImage = "http://ia.media-imdb.com/images/M/MV5BMjU4NDExNDM1NF5BMl5BanBnXkFtZTgwMDIyMTgxNzE@._V1_SX640_SY720_.jpg",
                    EnglishDescription = "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
                    Description = "The Revenant is een episch avontuur van één man over overleven en de buitengewone kracht van de menselijke geest. Tijdens een expeditie diep in de ruige Amerikaanse wildernis wordt de legendarische avonturier Hugh Glass aangevallen door een beer en voor dood achtergelaten door zijn gezelschap. Tijdens zijn overlevingstocht ondergaat Glass ondenkbare tegenslagen en wordt hij verraden door zijn vertrouweling John Fitzgerald. Gedreven door zijn wil om te leven en zijn liefde voor zijn familie, moet Glass zich een weg banen door een strenge winter tijdens zijn meedogenloze overlevingstocht om uiteindelijk verlossing te vinden.",
                    is3D = true,
                    ReleaseDate = DateTime.Parse("2016-03-03"),
                    Rates = rateListWithoutChild,
                    Genres = genreList1,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/QRfj1VCg16Y",
                    ImdbLink = "http://www.imdb.com/title/tt1663202/",
                    UserReview = 2
                },
                new Movie {
                    MovieId = 3,
                    Titel = "Star Wars: Episode VII - The Force Awakens",
                    Duration = 135,
                    Age = 12,
                    MovieImage = "http://ia.media-imdb.com/images/M/MV5BOTAzODEzNDAzMl5BMl5BanBnXkFtZTgwMDU1MTgzNzE@._V1_SX640_SY720_.jpg",
                    EnglishDescription = "Three decades after the defeat of the Galactic Empire, a new threat arises. The First Order attempts to rule the galaxy and only a ragtag group of heroes can stop them, along with the help of the Resistance.",
                    Description = "Three decades after the defeat of the Galactic Empire, a new threat arises. The First Order attempts to rule the galaxy and only a ragtag group of heroes can stop them, along with the help of the Resistance. ",
                    is3D = true,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-03"),
                    Genres = genreList2,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/sGbxmsDFVnE",
                    ImdbLink = "http://www.imdb.com/title/tt2488496/",
                    UserReview = 3
                },
                new Movie {
                    MovieId = 4,
                    Titel = "The Maze Runner: The Death Cure",
                    Duration = 135,
                    Age = 12,
                    MovieImage = "http://mygezza.com/wp-content/uploads/2015/04/The-Maze-Runner-3-The-Death-Curse.jpg",
                    EnglishDescription = "After having escaped the Maze, the Gladers now face a new set of challenges on the open roads of a desolate landscape filled with unimaginable obstacles.",
                    Description = "In dit tweede deel van de epische Maze Runner saga, krijgen Thomas en de andere Gladers te maken met hun grootste uitdaging tot nu toe: het zoeken naar aanwijzingen over de geheimzinnige en machtige organisatie WCKD. De tocht voert ze naar de Scorch, een troosteloos landschap met onvoorstelbare en gevaarlijke hindernissen. Samen met het verzet binden de Gladers de strijd aan met de superieure kracht van WCKD en ontdekken zij dat de organisatie een schokkend plan voor hen in petto heeft.",
                    is3D = false,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList3,
                    Language = "Dutch",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/AwwbhhjQ9Xk",
                    ImdbLink = "http://www.imdb.com/title/tt4500922/",
                    UserReview = 5
                },
                new Movie {
                    MovieId = 5,
                    Titel = "Captain America: Civil War",
                    Duration = 122,
                    Age = 12,
                    MovieImage = "http://pre04.deviantart.net/504a/th/pre/f/2015/352/c/e/captain_america__civil_war_fan_made_poster_by_omikonemswveridze-d9kkjsj.jpg",
                    EnglishDescription = "Political interference in the Avengers' activities causes a rift between former allies Captain America and Iron Man.",
                    Description = "In hun voortdurende pogingen de mensheid te beschermen, geeft Steve Rogers leiding aan de nieuwgevormde Avengers. Na een nieuw incident groeit de politieke druk om een systeem van toerekeningsvatbaarheid voor het team op te stellen. De nieuwe status quo splijt de Avengers, resulterend in twee kampen: een geleid door Steve Rogers en zijn verlangen om de Avengers vrij te houden en de ander door Tony Stark.",
                    is3D = false,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList3,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/xnv__ogkt0M",
                    ImdbLink = "http://www.imdb.com/title/tt3498820/",
                    UserReview = 4
                },
                new Movie {
                    MovieId = 6,
                    Titel = "Dirty Grandpa",
                    Duration = 102,
                    Age = 12,
                    MovieImage = "http://cdn01.cdn.justjared.com/wp-content/uploads/2016/01/efron-raves/zac-efron-raves-about-shirtless-robert-de-niro-dirty-grandpa-01.jpg",
                    EnglishDescription = "Right before his wedding, an uptight guy is tricked into driving his grandfather, a lecherous former Army Lieutenant-Colonel, to Florida for spring break.",
                    Description = "Over een week gaat de brave advocaat Jason (Zac Efron) trouwen met Meredith (Julianne Hough); een ontzettende control freak. Tussen alle huwelijksstress wil zijn opa (Robert De Niro) opeens een lift naar Florida. Maar daar is Spring Break in volle gang en komt het aanstaande huwelijk van Jason plots in gevaar. Want via uitzinnige feesten, bargevechten en een epische karaoke nacht is ‘vieze’ opa vast van plan zijn kleinzoon mee te sleuren in de wildste trip van hun leven!",
                    is3D = false,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList1,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/vOAn83vOZLk",
                    ImdbLink = "http://www.imdb.com/title/tt1860213/",
                    UserReview = 3
                },
                new Movie {
                    MovieId = 7,
                    Titel = "Achter de Wolken",
                    Duration = 87,
                    Age = 6,
                    MovieImage = "http://www.tarsenaal.be/files/downloads/AchterDeWolken_Affiche.jpg",
                    EnglishDescription = "Two people meet again after more than 50 years. They were lovers once, but their lives took different turns: she married his best friend. Fifty years later, they meet again and passion flares up. But is it possible to pick up the thread of a life that unraveled fifty years ago? The story of a wonderful last love affair, which is relived with the intensity of a first.",
                    Description = "Emma en Gerard komen elkaar na meer dan 50 jaar weer tegen. Ooit waren ze geliefden, maar het leven liep anders. Zij trouwde met zijn beste vriend. Vijftig jaar later vinden ze elkaar terug en worden opnieuw verliefd. Kan je aanknopen met wat je vijftig jaar eerder achterliet? Het verhaal van een overweldigende laatste liefde, beleefd met de intensiteit van de eerste.",
                    is3D = true,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList2,
                    Language = "Dutch",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/h5rQ6HUSJ8Y",
                    ImdbLink = "http://www.imdb.com/title/tt4440488/",
                    UserReview = 1
                },
                new Movie {
                    MovieId = 8,
                    Titel = "Helden van de Zee",
                    Duration = 65,
                    Age = 12,
                    MovieImage = "https://www.ketnet.be/sites/default/files/content/programma/helden/HVDZafficheKlein.png",
                    EnglishDescription = "Ketnet's heroes can't stop stunting. Not even during their adventurous holiday at the Belgian seaside. The first step? Transforming their residence in the dunes into a miniature theme park, including a thrilling roller coaster. Now they're all set for the summer of a lifetime. Especially Dempsey, who has fallen in love with Eva, a girl that's also on holiday. But their romance won't last long. Eva has to depart on a trip to England, where's she's enrolled in a language camp. The heroes want to comfort Dempsey and decide to go after her. The plan? Crossing the sea in boats they've made themselves. But after departure, not everything goes according to plan.",
                    Description = "De Helden van Ketnet kunnen het stunten niet laten. Ze trekken naar zee voor een avontuurlijke vakantie aan de Belgische kust. Van hun verblijfplaats in de duinen maken ze al snel een mini-pretpark. De zomer kan niet meer stuk, tot Dempsey verliefd wordt op Eva. Van de romance tussen Dempsey en Eva komt er weinig in huis want Eva vertrekt al snel naar Engeland op taalkamp. De Helden troosten Dempsey en beslissen om Eva achterna te gaan. Ze willen de zee oversteken in zelfgemaakte bootjes. Tsjik-tsjak-vollenbak ! Wanneer de Helden uitvaren, gaat het mis. Maar ze krijgen hulp van Jos, een zelfverklaarde zeevaarder die op een scheepskerkhof woont. De Helden bouwen een grote boot om tot een zeilschip en maken zich klaar voor de oversteek.",
                    is3D = true,
                    Rates = ratesList,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList2,
                    Language = "Dutch",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/embed/9muvEF5ohAQ",
                    ImdbLink = "http://www.imdb.com/title/tt5264304/",
                    UserReview = 1
                },
                new Movie {
                    MovieId = 9,
                    Titel = "Friends With Benefits",
                    Duration = 110,
                    Age = 16,
                    MovieImage = "http://ia.media-imdb.com/images/M/MV5BMTQ2MzQ0NTk4N15BMl5BanBnXkFtZTcwMDc2NDYzNQ@@._V1_SX640_SY720_.jpg",
                    EnglishDescription = "While trying to avoid the clichés of Hollywood romantic comedies, Dylan Harper and Jamie Rellis soon discover however that adding the act of sex to their friendship does lead to complications.",
                    Description = "Nadat ze ieder een rampzalige relatie hebben beëindigd, besluiten een vrouwelijke headhunter en haar nieuwste klant om seksmaatjes te worden. Ze beloven elkaar om ermee te stoppen wanneer een van beiden emotioneel gebonden raakt.",
                    is3D = false,
                    Rates = rateListWithLadies,
                    ReleaseDate = DateTime.Parse("2016-03-3"),
                    Genres = genreList2,
                    Language = "English",
                    Casts = castList,
                    Directors = directorList,
                    MovieTrailerUrl = "https://www.youtube.com/watch?v=ha2HZCNOAbc",
                    ImdbLink = "http://www.imdb.com/title/tt1632708/?ref_=nv_sr_1",
                    UserReview = 2
                }
            };

            context.Cinema.AddOrUpdate(
                new Cinema { CinemaId = 1, Name = "Cinevans", City = "Breda", Street = "Hogeschoollaan 1" }
            );

            //Zaal 1,  8 rijen 15 stoelen

            List<Row> rowListZaal1 = new List<Row>
            {
                new Row
                {
                    RowId = 1,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=1, SeatNumber =1, RowId = 1},
                        new Seat {SeatId=2, SeatNumber =2, RowId = 1},
                        new Seat {SeatId=3, SeatNumber =3, RowId = 1},
                        new Seat {SeatId=4, SeatNumber =4, RowId = 1},
                        new Seat {SeatId=5, SeatNumber =5, RowId = 1},
                        new Seat {SeatId=6, SeatNumber =6, RowId = 1},
                        new Seat {SeatId=7, SeatNumber =7, RowId = 1},
                        new Seat {SeatId=8, SeatNumber =8, RowId = 1},
                        new Seat {SeatId=9, SeatNumber =9, RowId = 1},
                        new Seat {SeatId=10, SeatNumber =10, RowId = 1},
                        new Seat {SeatId=11, SeatNumber =11, RowId = 1},
                        new Seat {SeatId=12, SeatNumber =12, RowId = 1},
                        new Seat {SeatId=13, SeatNumber =13, RowId = 1},
                        new Seat {SeatId=14, SeatNumber =14, RowId = 1},
                        new Seat {SeatId=15, SeatNumber =15, RowId = 1}
                    }
                },
                new Row
                {
                    RowId = 2,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=16, SeatNumber =1, RowId = 2},
                        new Seat {SeatId=17, SeatNumber =2, RowId = 2},
                        new Seat {SeatId=18, SeatNumber =3, RowId = 2},
                        new Seat {SeatId=19, SeatNumber =4, RowId = 2},
                        new Seat {SeatId=20, SeatNumber =5, RowId = 2},
                        new Seat {SeatId=21, SeatNumber =6, RowId = 2},
                        new Seat {SeatId=22, SeatNumber =7, RowId = 2},
                        new Seat {SeatId=23, SeatNumber =8, RowId = 2},
                        new Seat {SeatId=24, SeatNumber =9, RowId = 2},
                        new Seat {SeatId=25, SeatNumber =10, RowId = 2},
                        new Seat {SeatId=26, SeatNumber =11, RowId = 2},
                        new Seat {SeatId=27, SeatNumber =12, RowId = 2},
                        new Seat {SeatId=28, SeatNumber =13, RowId = 2},
                        new Seat {SeatId=29, SeatNumber =14, RowId = 2},
                        new Seat {SeatId=30, SeatNumber =15, RowId = 2}
                    }
                },
                new Row
                {
                    RowId = 3,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=31, SeatNumber =1, RowId = 3},
                        new Seat {SeatId=32, SeatNumber =2, RowId = 3},
                        new Seat {SeatId=33, SeatNumber =3, RowId = 3},
                        new Seat {SeatId=34, SeatNumber =4, RowId = 3},
                        new Seat {SeatId=35, SeatNumber =5, RowId = 3},
                        new Seat {SeatId=36, SeatNumber =6, RowId = 3},
                        new Seat {SeatId=37, SeatNumber =7, RowId = 3},
                        new Seat {SeatId=38, SeatNumber =8, RowId = 3},
                        new Seat {SeatId=39, SeatNumber =9, RowId = 3},
                        new Seat {SeatId=40, SeatNumber =10, RowId = 3},
                        new Seat {SeatId=41, SeatNumber =11, RowId = 3},
                        new Seat {SeatId=42, SeatNumber =12, RowId = 3},
                        new Seat {SeatId=43, SeatNumber =13, RowId = 3},
                        new Seat {SeatId=44, SeatNumber =14, RowId = 3},
                        new Seat {SeatId=45, SeatNumber =15, RowId = 3},
                    }
                },
                new Row
                {
                    RowId = 4,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=46, SeatNumber =1, RowId = 4},
                        new Seat {SeatId=47, SeatNumber =2, RowId = 4},
                        new Seat {SeatId=48, SeatNumber =3, RowId = 4},
                        new Seat {SeatId=49, SeatNumber =4, RowId = 4},
                        new Seat {SeatId=50, SeatNumber =5, RowId = 4},
                        new Seat {SeatId=51, SeatNumber =6, RowId = 4},
                        new Seat {SeatId=52, SeatNumber =7, RowId = 4},
                        new Seat {SeatId=53, SeatNumber =8, RowId = 4},
                        new Seat {SeatId=54, SeatNumber =9, RowId = 4},
                        new Seat {SeatId=55, SeatNumber =10, RowId = 4},
                        new Seat {SeatId=56, SeatNumber =11, RowId = 4},
                        new Seat {SeatId=57, SeatNumber =12, RowId = 4},
                        new Seat {SeatId=58, SeatNumber =13, RowId = 4},
                        new Seat {SeatId=59, SeatNumber =14, RowId = 4},
                        new Seat {SeatId=60, SeatNumber =15, RowId = 4},
                    }
                },
                new Row
                {
                    RowId = 5,
                    RowNumber = 5,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=61, SeatNumber =1, RowId = 5},
                        new Seat {SeatId=62, SeatNumber =2, RowId = 5},
                        new Seat {SeatId=63, SeatNumber =3, RowId = 5},
                        new Seat {SeatId=64, SeatNumber =4, RowId = 5},
                        new Seat {SeatId=65, SeatNumber =5, RowId = 5},
                        new Seat {SeatId=66, SeatNumber =6, RowId = 5},
                        new Seat {SeatId=67, SeatNumber =7, RowId = 5},
                        new Seat {SeatId=68, SeatNumber =8, RowId = 5},
                        new Seat {SeatId=69, SeatNumber =9, RowId = 5},
                        new Seat {SeatId=70, SeatNumber =10, RowId = 5},
                        new Seat {SeatId=71, SeatNumber =11, RowId = 5},
                        new Seat {SeatId=72, SeatNumber =12, RowId = 5},
                        new Seat {SeatId=73, SeatNumber =13, RowId = 5},
                        new Seat {SeatId=74, SeatNumber =14, RowId = 5},
                        new Seat {SeatId=75, SeatNumber =15, RowId = 5},
                    }
                },
                new Row
                {
                    RowId = 6,
                    RowNumber = 6,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=76, SeatNumber =1, RowId = 6},
                        new Seat {SeatId=77, SeatNumber =2, RowId = 6},
                        new Seat {SeatId=78, SeatNumber =3, RowId = 6},
                        new Seat {SeatId=79, SeatNumber =4, RowId = 6},
                        new Seat {SeatId=80, SeatNumber =5, RowId = 6},
                        new Seat {SeatId=81, SeatNumber =6, RowId = 6},
                        new Seat {SeatId=82, SeatNumber =7, RowId = 6},
                        new Seat {SeatId=83, SeatNumber =8, RowId = 6},
                        new Seat {SeatId=84, SeatNumber =9, RowId = 6},
                        new Seat {SeatId=85, SeatNumber =10, RowId = 6},
                        new Seat {SeatId=86, SeatNumber =11, RowId = 6},
                        new Seat {SeatId=87, SeatNumber =12, RowId = 6},
                        new Seat {SeatId=88, SeatNumber =13, RowId = 6},
                        new Seat {SeatId=89, SeatNumber =14, RowId = 6},
                        new Seat {SeatId=90, SeatNumber =15, RowId = 6},
                    }
                },
                new Row
                {
                    RowId = 7,
                    RowNumber = 7,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=91, SeatNumber =1, RowId = 7},
                        new Seat {SeatId=92, SeatNumber =2, RowId = 7},
                        new Seat {SeatId=93, SeatNumber =3, RowId = 7},
                        new Seat {SeatId=94, SeatNumber =4, RowId = 7},
                        new Seat {SeatId=95, SeatNumber =5, RowId = 7},
                        new Seat {SeatId=96, SeatNumber =6, RowId = 7},
                        new Seat {SeatId=97, SeatNumber =7, RowId = 7},
                        new Seat {SeatId=98, SeatNumber =8, RowId = 7},
                        new Seat {SeatId=99, SeatNumber =9, RowId = 7},
                        new Seat {SeatId=100, SeatNumber =10, RowId = 7},
                        new Seat {SeatId=101, SeatNumber =11, RowId = 7},
                        new Seat {SeatId=102, SeatNumber =12, RowId = 7},
                        new Seat {SeatId=103, SeatNumber =13, RowId = 7},
                        new Seat {SeatId=104, SeatNumber =14, RowId = 7},
                        new Seat {SeatId=105, SeatNumber =15, RowId = 7},
                    }
                },
                new Row
                {
                    RowId = 8,
                    RowNumber = 8,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=106, SeatNumber =1, RowId = 8},
                        new Seat {SeatId=107, SeatNumber =2, RowId = 8},
                        new Seat {SeatId=108, SeatNumber =3, RowId = 8},
                        new Seat {SeatId=109, SeatNumber =4, RowId = 8},
                        new Seat {SeatId=110, SeatNumber =5, RowId = 8},
                        new Seat {SeatId=111, SeatNumber =6, RowId = 8},
                        new Seat {SeatId=112, SeatNumber =7, RowId = 8},
                        new Seat {SeatId=113, SeatNumber =8, RowId = 8},
                        new Seat {SeatId=114, SeatNumber =9, RowId = 8},
                        new Seat {SeatId=115, SeatNumber =10, RowId = 8},
                        new Seat {SeatId=116, SeatNumber =11, RowId = 8},
                        new Seat {SeatId=117, SeatNumber =12, RowId = 8},
                        new Seat {SeatId=118, SeatNumber =13, RowId = 8},
                        new Seat {SeatId=119, SeatNumber =14, RowId = 8},
                        new Seat {SeatId=120, SeatNumber =15, RowId = 8},
                    }
                },

            };

            //Zaal 2,  8 rijen 15 stoelen
            List<Row> rowListZaal2 = new List<Row>
            {
                new Row
                {
                    RowId = 9,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=121, SeatNumber =1, RowId = 9},
                        new Seat {SeatId=122, SeatNumber =2, RowId = 9},
                        new Seat {SeatId=123, SeatNumber =3, RowId = 9},
                        new Seat {SeatId=124, SeatNumber =4, RowId = 9},
                        new Seat {SeatId=125, SeatNumber =5, RowId = 9},
                        new Seat {SeatId=126, SeatNumber =6, RowId = 9},
                        new Seat {SeatId=127, SeatNumber =7, RowId = 9},
                        new Seat {SeatId=128, SeatNumber =8, RowId = 9},
                        new Seat {SeatId=129, SeatNumber =9, RowId = 9},
                        new Seat {SeatId=130, SeatNumber =10, RowId = 9},
                        new Seat {SeatId=131, SeatNumber =11, RowId = 9},
                        new Seat {SeatId=132, SeatNumber =12, RowId = 9},
                        new Seat {SeatId=133, SeatNumber =13, RowId = 9},
                        new Seat {SeatId=134, SeatNumber =14, RowId = 9},
                        new Seat {SeatId=135, SeatNumber =15, RowId = 9},
                    }
                },
                new Row
                {
                    RowId = 10,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=136, SeatNumber =1, RowId = 10},
                        new Seat {SeatId=137, SeatNumber =2, RowId = 10},
                        new Seat {SeatId=138, SeatNumber =3, RowId = 10},
                        new Seat {SeatId=139, SeatNumber =4, RowId = 10},
                        new Seat {SeatId=140, SeatNumber =5, RowId = 10},
                        new Seat {SeatId=141, SeatNumber =6, RowId = 10},
                        new Seat {SeatId=142, SeatNumber =7, RowId = 10},
                        new Seat {SeatId=143, SeatNumber =8, RowId = 10},
                        new Seat {SeatId=144, SeatNumber =9, RowId = 10},
                        new Seat {SeatId=145, SeatNumber =10, RowId = 10},
                        new Seat {SeatId=146, SeatNumber =11, RowId = 10},
                        new Seat {SeatId=147, SeatNumber =12, RowId = 10},
                        new Seat {SeatId=148, SeatNumber =13, RowId = 10},
                        new Seat {SeatId=149, SeatNumber =14, RowId = 10},
                        new Seat {SeatId=150, SeatNumber =15, RowId = 10}
                    }
                },
                new Row
                {
                    RowId = 11,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=151, SeatNumber =1, RowId = 11},
                        new Seat {SeatId=152, SeatNumber =2, RowId = 11},
                        new Seat {SeatId=153, SeatNumber =3, RowId = 11},
                        new Seat {SeatId=154, SeatNumber =4, RowId = 11},
                        new Seat {SeatId=155, SeatNumber =5, RowId = 11},
                        new Seat {SeatId=156, SeatNumber =6, RowId = 11},
                        new Seat {SeatId=157, SeatNumber =7, RowId = 11},
                        new Seat {SeatId=158, SeatNumber =8, RowId = 11},
                        new Seat {SeatId=159, SeatNumber =9, RowId = 11},
                        new Seat {SeatId=160, SeatNumber =10, RowId = 11},
                        new Seat {SeatId=161, SeatNumber =11, RowId = 11},
                        new Seat {SeatId=162, SeatNumber =12, RowId = 11},
                        new Seat {SeatId=163, SeatNumber =13, RowId = 11},
                        new Seat {SeatId=164, SeatNumber =14, RowId = 11},
                        new Seat {SeatId=165, SeatNumber =15, RowId = 11}
                    }
                },
                new Row
                {
                    RowId = 12,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=166, SeatNumber =1, RowId = 12},
                        new Seat {SeatId=167, SeatNumber =2, RowId = 12},
                        new Seat {SeatId=168, SeatNumber =3, RowId = 12},
                        new Seat {SeatId=169, SeatNumber =4, RowId = 12},
                        new Seat {SeatId=170, SeatNumber =5, RowId = 12},
                        new Seat {SeatId=171, SeatNumber =6, RowId = 12},
                        new Seat {SeatId=172, SeatNumber =7, RowId = 12},
                        new Seat {SeatId=173, SeatNumber =8, RowId = 12},
                        new Seat {SeatId=174, SeatNumber =9, RowId = 12},
                        new Seat {SeatId=175, SeatNumber =10, RowId = 12},
                        new Seat {SeatId=176, SeatNumber =11, RowId = 12},
                        new Seat {SeatId=177, SeatNumber =12, RowId = 12},
                        new Seat {SeatId=178, SeatNumber =13, RowId = 12},
                        new Seat {SeatId=179, SeatNumber =14, RowId = 12},
                        new Seat {SeatId=180, SeatNumber =15, RowId = 12}
                    }
                },
                new Row
                {
                    RowId = 13,
                    RowNumber = 5,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=181, SeatNumber =1, RowId = 13},
                        new Seat {SeatId=182, SeatNumber =2, RowId = 13},
                        new Seat {SeatId=183, SeatNumber =3, RowId = 13},
                        new Seat {SeatId=184, SeatNumber =4, RowId = 13},
                        new Seat {SeatId=185, SeatNumber =5, RowId = 13},
                        new Seat {SeatId=186, SeatNumber =6, RowId = 13},
                        new Seat {SeatId=187, SeatNumber =7, RowId = 13},
                        new Seat {SeatId=188, SeatNumber =8, RowId = 13},
                        new Seat {SeatId=189, SeatNumber =9, RowId = 13},
                        new Seat {SeatId=190, SeatNumber =10, RowId = 13},
                        new Seat {SeatId=191, SeatNumber =11, RowId = 13},
                        new Seat {SeatId=192, SeatNumber =12, RowId = 13},
                        new Seat {SeatId=193, SeatNumber =13, RowId = 13},
                        new Seat {SeatId=194, SeatNumber =14, RowId = 13},
                        new Seat {SeatId=195, SeatNumber =15, RowId = 13}
                    }
                },
                new Row
                {
                    RowId = 14,
                    RowNumber = 6,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=196, SeatNumber =1, RowId = 14},
                        new Seat {SeatId=197, SeatNumber =2, RowId = 14},
                        new Seat {SeatId=198, SeatNumber =3, RowId = 14},
                        new Seat {SeatId=199, SeatNumber =4, RowId = 14},
                        new Seat {SeatId=200, SeatNumber =5, RowId = 14},
                        new Seat {SeatId=201, SeatNumber =6, RowId = 14},
                        new Seat {SeatId=202, SeatNumber =7, RowId = 14},
                        new Seat {SeatId=203, SeatNumber =8, RowId = 14},
                        new Seat {SeatId=204, SeatNumber =9, RowId = 14},
                        new Seat {SeatId=205, SeatNumber =10, RowId = 14},
                        new Seat {SeatId=206, SeatNumber =11, RowId = 14},
                        new Seat {SeatId=207, SeatNumber =12, RowId = 14},
                        new Seat {SeatId=208, SeatNumber =13, RowId = 14},
                        new Seat {SeatId=209, SeatNumber =14, RowId = 14},
                        new Seat {SeatId=210, SeatNumber =15, RowId = 14}
                    }
                },
                new Row
                {
                    RowId = 15,
                    RowNumber = 7,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=211, SeatNumber =1, RowId = 15},
                        new Seat {SeatId=212, SeatNumber =2, RowId = 15},
                        new Seat {SeatId=213, SeatNumber =3, RowId = 15},
                        new Seat {SeatId=214, SeatNumber =4, RowId = 15},
                        new Seat {SeatId=215, SeatNumber =5, RowId = 15},
                        new Seat {SeatId=216, SeatNumber =6, RowId = 15},
                        new Seat {SeatId=217, SeatNumber =7, RowId = 15},
                        new Seat {SeatId=218, SeatNumber =8, RowId = 15},
                        new Seat {SeatId=219, SeatNumber =9, RowId = 15},
                        new Seat {SeatId=220, SeatNumber =10, RowId = 15},
                        new Seat {SeatId=221, SeatNumber =11, RowId = 15},
                        new Seat {SeatId=222, SeatNumber =12, RowId = 15},
                        new Seat {SeatId=223, SeatNumber =13, RowId = 15},
                        new Seat {SeatId=224, SeatNumber =14, RowId = 15},
                        new Seat {SeatId=225, SeatNumber =15, RowId = 15}
                    }
                },
                new Row
                {
                    RowId = 16,
                    RowNumber = 8,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=226, SeatNumber =1, RowId = 16},
                        new Seat {SeatId=227, SeatNumber =2, RowId = 16},
                        new Seat {SeatId=228, SeatNumber =3, RowId = 16},
                        new Seat {SeatId=229, SeatNumber =4, RowId = 16},
                        new Seat {SeatId=230, SeatNumber =5, RowId = 16},
                        new Seat {SeatId=231, SeatNumber =6, RowId = 16},
                        new Seat {SeatId=232, SeatNumber =7, RowId = 16},
                        new Seat {SeatId=233, SeatNumber =8, RowId = 16},
                        new Seat {SeatId=234, SeatNumber =9, RowId = 16},
                        new Seat {SeatId=235, SeatNumber =10, RowId = 16},
                        new Seat {SeatId=236, SeatNumber =11, RowId = 16},
                        new Seat {SeatId=237, SeatNumber =12, RowId = 16},
                        new Seat {SeatId=238, SeatNumber =13, RowId = 16},
                        new Seat {SeatId=239, SeatNumber =14, RowId = 16},
                        new Seat {SeatId=240, SeatNumber =15, RowId = 16}
                    }
                },

            };

            //Zaal 3, 8 rijen 15 stoelen
            List<Row> rowListZaal3 = new List<Row>
            {
                new Row
                {
                    RowId = 17,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=241, SeatNumber =1, RowId = 17},
                        new Seat {SeatId=242, SeatNumber =2, RowId = 17},
                        new Seat {SeatId=243, SeatNumber =3, RowId = 17},
                        new Seat {SeatId=244, SeatNumber =4, RowId = 17},
                        new Seat {SeatId=245, SeatNumber =5, RowId = 17},
                        new Seat {SeatId=246, SeatNumber =6, RowId = 17},
                        new Seat {SeatId=247, SeatNumber =7, RowId = 17},
                        new Seat {SeatId=248, SeatNumber =8, RowId = 17},
                        new Seat {SeatId=249, SeatNumber =9, RowId = 17},
                        new Seat {SeatId=250, SeatNumber =10, RowId = 17},
                        new Seat {SeatId=251, SeatNumber =11, RowId = 17},
                        new Seat {SeatId=252, SeatNumber =12, RowId = 17},
                        new Seat {SeatId=253, SeatNumber =13, RowId = 17},
                        new Seat {SeatId=254, SeatNumber =14, RowId = 17},
                        new Seat {SeatId=255, SeatNumber =15, RowId = 17}
                    }
                },
                new Row
                {
                    RowId = 18,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=256, SeatNumber =1, RowId = 18},
                        new Seat {SeatId=257, SeatNumber =2, RowId = 18},
                        new Seat {SeatId=258, SeatNumber =3, RowId = 18},
                        new Seat {SeatId=259, SeatNumber =4, RowId = 18},
                        new Seat {SeatId=260, SeatNumber =5, RowId = 18},
                        new Seat {SeatId=261, SeatNumber =6, RowId = 18},
                        new Seat {SeatId=262, SeatNumber =7, RowId = 18},
                        new Seat {SeatId=263, SeatNumber =8, RowId = 18},
                        new Seat {SeatId=264, SeatNumber =9, RowId = 18},
                        new Seat {SeatId=265, SeatNumber =10, RowId = 18},
                        new Seat {SeatId=266, SeatNumber =11, RowId = 18},
                        new Seat {SeatId=267, SeatNumber =12, RowId = 18},
                        new Seat {SeatId=268, SeatNumber =13, RowId = 18},
                        new Seat {SeatId=269, SeatNumber =14, RowId = 18},
                        new Seat {SeatId=270, SeatNumber =15, RowId = 18}
                    }
                },
                new Row
                {
                    RowId = 19,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=271, SeatNumber =1, RowId = 19},
                        new Seat {SeatId=272, SeatNumber =2, RowId = 19},
                        new Seat {SeatId=273, SeatNumber =3, RowId = 19},
                        new Seat {SeatId=274, SeatNumber =4, RowId = 19},
                        new Seat {SeatId=275, SeatNumber =5, RowId = 19},
                        new Seat {SeatId=276, SeatNumber =6, RowId = 19},
                        new Seat {SeatId=277, SeatNumber =7, RowId = 19},
                        new Seat {SeatId=278, SeatNumber =8, RowId = 19},
                        new Seat {SeatId=279, SeatNumber =9, RowId = 19},
                        new Seat {SeatId=280, SeatNumber =10, RowId = 19},
                        new Seat {SeatId=281, SeatNumber =11, RowId = 19},
                        new Seat {SeatId=282, SeatNumber =12, RowId = 19},
                        new Seat {SeatId=283, SeatNumber =13, RowId = 19},
                        new Seat {SeatId=284, SeatNumber =14, RowId = 19},
                        new Seat {SeatId=285, SeatNumber =15, RowId = 19}
                    }
                },
                new Row
                {
                    RowId = 20,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=286, SeatNumber =1, RowId = 20},
                        new Seat {SeatId=287, SeatNumber =2, RowId = 20},
                        new Seat {SeatId=288, SeatNumber =3, RowId = 20},
                        new Seat {SeatId=289, SeatNumber =4, RowId = 20},
                        new Seat {SeatId=290, SeatNumber =5, RowId = 20},
                        new Seat {SeatId=291, SeatNumber =6, RowId = 20},
                        new Seat {SeatId=292, SeatNumber =7, RowId = 20},
                        new Seat {SeatId=293, SeatNumber =8, RowId = 20},
                        new Seat {SeatId=294, SeatNumber =9, RowId = 20},
                        new Seat {SeatId=295, SeatNumber =10, RowId = 20},
                        new Seat {SeatId=296, SeatNumber =11, RowId = 20},
                        new Seat {SeatId=297, SeatNumber =12, RowId = 20},
                        new Seat {SeatId=298, SeatNumber =13, RowId = 20},
                        new Seat {SeatId=299, SeatNumber =14, RowId = 20},
                        new Seat {SeatId=300, SeatNumber =15, RowId = 20}
                    }
                },
                new Row
                {
                    RowId = 21,
                    RowNumber = 5,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=301, SeatNumber =1, RowId = 21},
                        new Seat {SeatId=302, SeatNumber =2, RowId = 21},
                        new Seat {SeatId=303, SeatNumber =3, RowId = 21},
                        new Seat {SeatId=304, SeatNumber =4, RowId = 21},
                        new Seat {SeatId=305, SeatNumber =5, RowId = 21},
                        new Seat {SeatId=306, SeatNumber =6, RowId = 21},
                        new Seat {SeatId=307, SeatNumber =7, RowId = 21},
                        new Seat {SeatId=308, SeatNumber =8, RowId = 21},
                        new Seat {SeatId=309, SeatNumber =9, RowId = 21},
                        new Seat {SeatId=310, SeatNumber =10, RowId = 21},
                        new Seat {SeatId=311, SeatNumber =11, RowId = 21},
                        new Seat {SeatId=312, SeatNumber =12, RowId = 21},
                        new Seat {SeatId=313, SeatNumber =13, RowId = 21},
                        new Seat {SeatId=314, SeatNumber =14, RowId = 21},
                        new Seat {SeatId=315, SeatNumber =15, RowId = 21}
                    }
                },
                new Row
                {
                    RowId = 22,
                    RowNumber = 6,
                    Seats = new List<Seat>()
                    {
                        new Seat {SeatId=316, SeatNumber =1, RowId = 22},
                        new Seat {SeatId=317, SeatNumber =2, RowId = 22},
                        new Seat {SeatId=318, SeatNumber =3, RowId = 22},
                        new Seat {SeatId=319, SeatNumber =4, RowId = 22},
                        new Seat {SeatId=320, SeatNumber =5, RowId = 22},
                        new Seat {SeatId=321, SeatNumber =6, RowId = 22},
                        new Seat {SeatId=322, SeatNumber =7, RowId = 22},
                        new Seat {SeatId=323, SeatNumber =8, RowId = 22},
                        new Seat {SeatId=324, SeatNumber =9, RowId = 22},
                        new Seat {SeatId=325, SeatNumber =10, RowId = 22},
                        new Seat {SeatId=326, SeatNumber =11, RowId = 22},
                        new Seat {SeatId=327, SeatNumber =12, RowId = 22},
                        new Seat {SeatId=328, SeatNumber =13, RowId = 22},
                        new Seat {SeatId=329, SeatNumber =14, RowId = 22},
                        new Seat {SeatId=330, SeatNumber =15, RowId = 22}
                    }
                },
                new Row
                {
                    RowId = 23,
                    RowNumber = 7,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=331, SeatNumber =1, RowId = 23},
                    new Seat {SeatId=332, SeatNumber =2, RowId = 23},
                    new Seat {SeatId=333, SeatNumber =3, RowId = 23},
                    new Seat {SeatId=334, SeatNumber =4, RowId = 23},
                    new Seat {SeatId=335, SeatNumber =5, RowId = 23},
                    new Seat {SeatId=336, SeatNumber =6, RowId = 23},
                    new Seat {SeatId=337, SeatNumber =7, RowId = 23},
                    new Seat {SeatId=338, SeatNumber =8, RowId = 23},
                    new Seat {SeatId=339, SeatNumber =9, RowId = 23},
                    new Seat {SeatId=340, SeatNumber =10, RowId = 23},
                    new Seat {SeatId=341, SeatNumber =11, RowId = 23},
                    new Seat {SeatId=342, SeatNumber =12, RowId = 23},
                    new Seat {SeatId=343, SeatNumber =13, RowId = 23},
                    new Seat {SeatId=344, SeatNumber =14, RowId = 23},
                    new Seat {SeatId=345, SeatNumber =15, RowId = 23}
                    }
                },
                new Row
                {
                    RowId = 24,
                    RowNumber = 8,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=346, SeatNumber =1, RowId = 24},
                    new Seat {SeatId=347, SeatNumber =2, RowId = 24},
                    new Seat {SeatId=348, SeatNumber =3, RowId = 24},
                    new Seat {SeatId=349, SeatNumber =4, RowId = 24},
                    new Seat {SeatId=350, SeatNumber =5, RowId = 24},
                    new Seat {SeatId=351, SeatNumber =6, RowId = 24},
                    new Seat {SeatId=352, SeatNumber =7, RowId = 24},
                    new Seat {SeatId=353, SeatNumber =8, RowId = 24},
                    new Seat {SeatId=354, SeatNumber =9, RowId = 24},
                    new Seat {SeatId=355, SeatNumber =10, RowId = 24},
                    new Seat {SeatId=356, SeatNumber =11, RowId = 24},
                    new Seat {SeatId=357, SeatNumber =12, RowId = 24},
                    new Seat {SeatId=358, SeatNumber =13, RowId = 24},
                    new Seat {SeatId=359, SeatNumber =14, RowId = 24},
                    new Seat {SeatId=360, SeatNumber =15, RowId = 24}
                    }
                },

            };

            //Zaal 4, 6 rijen 10 stoelen
            List<Row> rowListZaal4 = new List<Row>
            {
                new Row
                {
                    RowId = 25,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=361, SeatNumber =1, RowId = 25},
                    new Seat {SeatId=362, SeatNumber =2, RowId = 25},
                    new Seat {SeatId=363, SeatNumber =3, RowId = 25},
                    new Seat {SeatId=364, SeatNumber =4, RowId = 25},
                    new Seat {SeatId=365, SeatNumber =5, RowId = 25},
                    new Seat {SeatId=366, SeatNumber =6, RowId = 25},
                    new Seat {SeatId=367, SeatNumber =7, RowId = 25},
                    new Seat {SeatId=368, SeatNumber =8, RowId = 25},
                    new Seat {SeatId=369, SeatNumber =9, RowId = 25},
                    new Seat {SeatId=370, SeatNumber =10, RowId = 25}
                    }
                },
                new Row
                {
                    RowId = 26,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=371, SeatNumber =1, RowId = 26},
                    new Seat {SeatId=372, SeatNumber =2, RowId = 26},
                    new Seat {SeatId=373, SeatNumber =3, RowId = 26},
                    new Seat {SeatId=374, SeatNumber =4, RowId = 26},
                    new Seat {SeatId=375, SeatNumber =5, RowId = 26},
                    new Seat {SeatId=376, SeatNumber =6, RowId = 26},
                    new Seat {SeatId=377, SeatNumber =7, RowId = 26},
                    new Seat {SeatId=378, SeatNumber =8, RowId = 26},
                    new Seat {SeatId=379, SeatNumber =9, RowId = 26},
                    new Seat {SeatId=380, SeatNumber =10, RowId = 26}
                    }
                },
                new Row
                {
                    RowId = 27,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=381, SeatNumber =1, RowId = 27},
                    new Seat {SeatId=382, SeatNumber =2, RowId = 27},
                    new Seat {SeatId=383, SeatNumber =3, RowId = 27},
                    new Seat {SeatId=384, SeatNumber =4, RowId = 27},
                    new Seat {SeatId=385, SeatNumber =5, RowId = 27},
                    new Seat {SeatId=386, SeatNumber =6, RowId = 27},
                    new Seat {SeatId=387, SeatNumber =7, RowId = 27},
                    new Seat {SeatId=388, SeatNumber =8, RowId = 27},
                    new Seat {SeatId=389, SeatNumber =9, RowId = 27},
                    new Seat {SeatId=390, SeatNumber =10, RowId = 27}
                    }
                },
                new Row
                {
                    RowId = 28,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=391, SeatNumber =1, RowId = 28},
                    new Seat {SeatId=392, SeatNumber =2, RowId = 28},
                    new Seat {SeatId=393, SeatNumber =3, RowId = 28},
                    new Seat {SeatId=394, SeatNumber =4, RowId = 28},
                    new Seat {SeatId=395, SeatNumber =5, RowId = 28},
                    new Seat {SeatId=396, SeatNumber =6, RowId = 28},
                    new Seat {SeatId=397, SeatNumber =7, RowId = 28},
                    new Seat {SeatId=398, SeatNumber =8, RowId = 28},
                    new Seat {SeatId=399, SeatNumber =9, RowId = 28},
                    new Seat {SeatId=400, SeatNumber =10, RowId = 28}
                    }
                },
                new Row
                {
                    RowId = 29,
                    RowNumber = 5,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=401, SeatNumber =1, RowId = 29},
                    new Seat {SeatId=402, SeatNumber =2, RowId = 29},
                    new Seat {SeatId=403, SeatNumber =3, RowId = 29},
                    new Seat {SeatId=404, SeatNumber =4, RowId = 29},
                    new Seat {SeatId=405, SeatNumber =5, RowId = 29},
                    new Seat {SeatId=406, SeatNumber =6, RowId = 29},
                    new Seat {SeatId=407, SeatNumber =7, RowId = 29},
                    new Seat {SeatId=408, SeatNumber =8, RowId = 29},
                    new Seat {SeatId=409, SeatNumber =9, RowId = 29},
                    new Seat {SeatId=410, SeatNumber =10, RowId = 29}
                    }
                },
                new Row
                {
                    RowId = 30,
                    RowNumber = 6,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=411, SeatNumber =1, RowId = 30},
                    new Seat {SeatId=412, SeatNumber =2, RowId = 30},
                    new Seat {SeatId=413, SeatNumber =3, RowId = 30},
                    new Seat {SeatId=414, SeatNumber =4, RowId = 30},
                    new Seat {SeatId=415, SeatNumber =5, RowId = 30},
                    new Seat {SeatId=416, SeatNumber =6, RowId = 30},
                    new Seat {SeatId=417, SeatNumber =7, RowId = 30},
                    new Seat {SeatId=418, SeatNumber =8, RowId = 30},
                    new Seat {SeatId=419, SeatNumber =9, RowId = 30},
                    new Seat {SeatId=420, SeatNumber =10, RowId = 30}
                    }
                },
            };

            //Zaal 5, 2 rijen 10 stoelen, 2 rijen 15 stoelen
            List<Row> rowListZaal5 = new List<Row>
            {
                new Row
                {
                    RowId = 31,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=421, SeatNumber =1, RowId = 31},
                    new Seat {SeatId=422, SeatNumber =2, RowId = 31},
                    new Seat {SeatId=423, SeatNumber =3, RowId = 31},
                    new Seat {SeatId=424, SeatNumber =4, RowId = 31},
                    new Seat {SeatId=425, SeatNumber =5, RowId = 31},
                    new Seat {SeatId=426, SeatNumber =6, RowId = 31},
                    new Seat {SeatId=427, SeatNumber =7, RowId = 31},
                    new Seat {SeatId=428, SeatNumber =8, RowId = 31},
                    new Seat {SeatId=429, SeatNumber =9, RowId = 31},
                    new Seat {SeatId=430, SeatNumber =10, RowId = 31},
                    }
                },
                new Row
                {
                    RowId = 32,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=431, SeatNumber =1, RowId = 32},
                    new Seat {SeatId=432, SeatNumber =2, RowId = 32},
                    new Seat {SeatId=433, SeatNumber =3, RowId = 32},
                    new Seat {SeatId=434, SeatNumber =4, RowId = 32},
                    new Seat {SeatId=435, SeatNumber =5, RowId = 32},
                    new Seat {SeatId=436, SeatNumber =6, RowId = 32},
                    new Seat {SeatId=437, SeatNumber =7, RowId = 32},
                    new Seat {SeatId=438, SeatNumber =8, RowId = 32},
                    new Seat {SeatId=439, SeatNumber =9, RowId = 32},
                    new Seat {SeatId=440, SeatNumber =10, RowId = 32},
                    }
                },
                new Row
                {
                    RowId = 33,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=441, SeatNumber =1, RowId = 33},
                    new Seat {SeatId=442, SeatNumber =2, RowId = 33},
                    new Seat {SeatId=443, SeatNumber =3, RowId = 33},
                    new Seat {SeatId=444, SeatNumber =4, RowId = 33},
                    new Seat {SeatId=445, SeatNumber =5, RowId = 33},
                    new Seat {SeatId=446, SeatNumber =6, RowId = 33},
                    new Seat {SeatId=447, SeatNumber =7, RowId = 33},
                    new Seat {SeatId=448, SeatNumber =8, RowId = 33},
                    new Seat {SeatId=449, SeatNumber =9, RowId = 33},
                    new Seat {SeatId=450, SeatNumber =10, RowId = 33},
                    new Seat {SeatId=451, SeatNumber =11, RowId = 33},
                    new Seat {SeatId=452, SeatNumber =12, RowId = 33},
                    new Seat {SeatId=453, SeatNumber =13, RowId = 33},
                    new Seat {SeatId=454, SeatNumber =14, RowId = 33},
                    new Seat {SeatId=455, SeatNumber =15, RowId = 33}
                    }
                },
                new Row
                {
                    RowId = 34,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=456, SeatNumber =1, RowId = 34},
                    new Seat {SeatId=457, SeatNumber =2, RowId = 34},
                    new Seat {SeatId=458, SeatNumber =3, RowId = 34},
                    new Seat {SeatId=459, SeatNumber =4, RowId = 34},
                    new Seat {SeatId=460, SeatNumber =5, RowId = 34},
                    new Seat {SeatId=461, SeatNumber =6, RowId = 34},
                    new Seat {SeatId=462, SeatNumber =7, RowId = 34},
                    new Seat {SeatId=463, SeatNumber =8, RowId = 34},
                    new Seat {SeatId=464, SeatNumber =9, RowId = 34},
                    new Seat {SeatId=465, SeatNumber =10, RowId = 34},
                    new Seat {SeatId=466, SeatNumber =11, RowId = 34},
                    new Seat {SeatId=467, SeatNumber =12, RowId = 34},
                    new Seat {SeatId=468, SeatNumber =13, RowId = 34},
                    new Seat {SeatId=469, SeatNumber =14, RowId = 34},
                    new Seat {SeatId=470, SeatNumber =15, RowId = 34}
                    }
                },

            };

            //Zaal 6, 2 rijen 10 stoelen , 2 rijen 15 stoelen
            List<Row> rowListZaal6 = new List<Row>
            {
                new Row
                {
                    RowId = 35,
                    RowNumber = 1,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=471, SeatNumber =1, RowId = 35},
                    new Seat {SeatId=472, SeatNumber =2, RowId = 35},
                    new Seat {SeatId=473, SeatNumber =3, RowId = 35},
                    new Seat {SeatId=474, SeatNumber =4, RowId = 35},
                    new Seat {SeatId=475, SeatNumber =5, RowId = 35},
                    new Seat {SeatId=476, SeatNumber =6, RowId = 35},
                    new Seat {SeatId=477, SeatNumber =7, RowId = 35},
                    new Seat {SeatId=478, SeatNumber =8, RowId = 35},
                    new Seat {SeatId=479, SeatNumber =9, RowId = 35},
                    new Seat {SeatId=480, SeatNumber =10, RowId = 35}
                    }
                },
                new Row
                {
                    RowId = 36,
                    RowNumber = 2,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=481, SeatNumber =1, RowId = 36},
                    new Seat {SeatId=482, SeatNumber =2, RowId = 36},
                    new Seat {SeatId=483, SeatNumber =3, RowId = 36},
                    new Seat {SeatId=484, SeatNumber =4, RowId = 36},
                    new Seat {SeatId=485, SeatNumber =5, RowId = 36},
                    new Seat {SeatId=486, SeatNumber =6, RowId = 36},
                    new Seat {SeatId=487, SeatNumber =7, RowId = 36},
                    new Seat {SeatId=488, SeatNumber =8, RowId = 36},
                    new Seat {SeatId=489, SeatNumber =9, RowId = 36},
                    new Seat {SeatId=490, SeatNumber =10, RowId = 36}
                    }
                },
                new Row
                {
                    RowId = 37,
                    RowNumber = 3,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=491, SeatNumber =1, RowId = 37},
                    new Seat {SeatId=492, SeatNumber =2, RowId = 37},
                    new Seat {SeatId=493, SeatNumber =3, RowId = 37},
                    new Seat {SeatId=494, SeatNumber =4, RowId = 37},
                    new Seat {SeatId=495, SeatNumber =5, RowId = 37},
                    new Seat {SeatId=496, SeatNumber =6, RowId = 37},
                    new Seat {SeatId=497, SeatNumber =7, RowId = 37},
                    new Seat {SeatId=498, SeatNumber =8, RowId = 37},
                    new Seat {SeatId=499, SeatNumber =9, RowId = 37},
                    new Seat {SeatId=500, SeatNumber =10, RowId = 37},
                    new Seat {SeatId=501, SeatNumber =11, RowId = 37},
                    new Seat {SeatId=502, SeatNumber =12, RowId = 37},
                    new Seat {SeatId=503, SeatNumber =13, RowId = 37},
                    new Seat {SeatId=504, SeatNumber =14, RowId = 37},
                    new Seat {SeatId=505, SeatNumber =15, RowId = 37}
                    }
                },
                new Row
                {
                    RowId = 38,
                    RowNumber = 4,
                    Seats = new List<Seat>()
                    {
                    new Seat {SeatId=506, SeatNumber =1, RowId = 38},
                    new Seat {SeatId=507, SeatNumber =2, RowId = 38},
                    new Seat {SeatId=508, SeatNumber =3, RowId = 38},
                    new Seat {SeatId=509, SeatNumber =4, RowId = 38},
                    new Seat {SeatId=510, SeatNumber =5, RowId = 38},
                    new Seat {SeatId=511, SeatNumber =6, RowId = 38},
                    new Seat {SeatId=512, SeatNumber =7, RowId = 38},
                    new Seat {SeatId=513, SeatNumber =8, RowId = 38},
                    new Seat {SeatId=514, SeatNumber =9, RowId = 38},
                    new Seat {SeatId=515, SeatNumber =10, RowId = 38},
                    new Seat {SeatId=516, SeatNumber =11, RowId = 38},
                    new Seat {SeatId=517, SeatNumber =12, RowId = 38},
                    new Seat {SeatId=518, SeatNumber =13, RowId = 38},
                    new Seat {SeatId=519, SeatNumber =14, RowId = 38},
                    new Seat {SeatId=520, SeatNumber =15, RowId = 38}
                    }
                },

            };

            //Zalen

            List<Room> roomList = new List<Room>
            {
                new Room
                {
                    RoomId = 1, RoomName = "Zaal 1", Accessbility = true, is3D = true, Rows = rowListZaal1
                },

                new Room
                {
                     RoomId = 2, RoomName = "Zaal 2", Accessbility = true, is3D = true , Rows = rowListZaal2
                },

                new Room
                {
                     RoomId = 3, RoomName = "Zaal 3", Accessbility = true, is3D = false , Rows = rowListZaal3
                },

                new Room
                {
                    RoomId = 4, RoomName = "Zaal 4", Accessbility = true, is3D = false , Rows = rowListZaal4
                },

                new Room
                {
                    RoomId = 5, RoomName = "Zaal 5", Accessbility = false, is3D = false , Rows = rowListZaal5
                },

                new Room
                {
                    RoomId = 6, RoomName = "Zaal 6", Accessbility = false, is3D = false , Rows = rowListZaal6
                }
            };

            //Viewings
            List<Viewing> viewingList = new List<Viewing>
            {
                new Viewing
                {
                    ViewingId = 1, MovieId = 1, RoomId = 3, StartTime = DateTime.Now.AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 2, MovieId = 2, RoomId = 1, StartTime = DateTime.Now.AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 3, MovieId = 3, RoomId = 2, StartTime = DateTime.Now.AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 4, MovieId = 4, RoomId = 4, StartTime = DateTime.Now.AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 5, MovieId = 3, RoomId = 1, StartTime = DateTime.Now.AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 6, MovieId = 1, RoomId = 6, StartTime = DateTime.Now.AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 7, MovieId = 1, RoomId = 6, StartTime = DateTime.Now.AddDays(1)
                },
                new Viewing
                {
                    ViewingId = 38, MovieId = 9, RoomId = 3, StartTime = DateTime.Now.AddDays(1)
                },
                new Viewing
                {
                    ViewingId = 40, MovieId = 7, RoomId = 1, StartTime = DateTime.Now.AddDays(1)
                },
                new Viewing
                {
                    ViewingId = 39, MovieId = 8, RoomId = 1, StartTime = DateTime.Now.AddDays(1).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 41, MovieId = 3, RoomId = 2, StartTime = DateTime.Now.AddDays(1).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 42, MovieId = 1, RoomId = 4, StartTime = DateTime.Now.AddDays(1).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 8, MovieId = 1, RoomId = 5, StartTime = DateTime.Now.AddDays(2).AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 9, MovieId = 2, RoomId = 2, StartTime = DateTime.Now.AddDays(2)
                },
                new Viewing
                {
                    ViewingId = 10, MovieId = 3, RoomId = 1, StartTime = DateTime.Now.AddDays(2)
                },
                new Viewing
                {
                    ViewingId = 11, MovieId = 4, RoomId = 4, StartTime = DateTime.Now.AddDays(2)
                },
                new Viewing
                {
                    ViewingId = 12, MovieId = 5, RoomId = 5, StartTime = DateTime.Now.AddDays(2).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 13, MovieId = 6, RoomId = 6, StartTime = DateTime.Now.AddDays(2)
                },
                new Viewing
                {
                    ViewingId = 14, MovieId = 4, RoomId = 5, StartTime = DateTime.Now.AddDays(3)
                },
                new Viewing
                {
                    ViewingId = 15, MovieId = 5, RoomId = 4, StartTime = DateTime.Now.AddDays(3)
                },
                new Viewing
                {
                    ViewingId = 16, MovieId = 6, RoomId = 3, StartTime = DateTime.Now.AddDays(3)
                },
                new Viewing
                {
                    ViewingId = 17, MovieId = 7, RoomId = 2, StartTime = DateTime.Now.AddDays(3)
                },
                new Viewing
                {
                    ViewingId = 18, MovieId = 8, RoomId = 1, StartTime = DateTime.Now.AddDays(3).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 43, MovieId = 1, RoomId = 4, StartTime = DateTime.Now.AddDays(3).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 19, MovieId = 1, RoomId = 6, StartTime = DateTime.Now.AddDays(4).AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 20, MovieId = 3, RoomId = 2, StartTime = DateTime.Now.AddDays(4).AddHours(3)
                },
                new Viewing
                {
                    ViewingId = 21, MovieId = 5, RoomId = 3, StartTime = DateTime.Now.AddDays(4).AddHours(5)
                },
                new Viewing
                {
                    ViewingId = 40, MovieId = 9, RoomId = 6, StartTime = DateTime.Now.AddDays(4).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 22, MovieId = 7, RoomId = 1, StartTime = DateTime.Now.AddDays(4).AddHours(6)
                },
                new Viewing
                {
                    ViewingId = 23, MovieId = 8, RoomId = 2, StartTime = DateTime.Now.AddDays(4).AddHours(6)
                },
                new Viewing
                {
                    ViewingId = 24, MovieId = 2, RoomId = 1, StartTime = DateTime.Now.AddDays(5).AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 25, MovieId = 3, RoomId = 2, StartTime = DateTime.Now.AddDays(5).AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 26, MovieId = 4, RoomId = 3, StartTime = DateTime.Now.AddDays(5).AddHours(3)
                },
                new Viewing
                {
                    ViewingId = 27, MovieId = 6, RoomId = 4, StartTime = DateTime.Now.AddDays(5).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 28, MovieId = 7, RoomId = 1, StartTime = DateTime.Now.AddDays(5).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 29, MovieId = 8, RoomId = 2, StartTime = DateTime.Now.AddDays(5).AddHours(5)
                },
                new Viewing
                {
                    ViewingId = 30, MovieId = 5, RoomId = 3, StartTime = DateTime.Now.AddDays(6)
                },
                new Viewing
                {
                    ViewingId = 31, MovieId = 6, RoomId = 4, StartTime = DateTime.Now.AddDays(6)
                },
                new Viewing
                {
                    ViewingId = 32, MovieId = 7, RoomId = 1, StartTime = DateTime.Now.AddDays(6).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 33, MovieId = 8, RoomId = 2, StartTime = DateTime.Now.AddDays(6).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 46, MovieId = 1, RoomId = 5, StartTime = DateTime.Now.AddDays(6).AddHours(2)
                },
                new Viewing
                {
                    ViewingId = 47, MovieId = 4, RoomId = 6, StartTime = DateTime.Now.AddDays(6).AddHours(3)
                },
                new Viewing
                {
                    ViewingId = 34, MovieId = 1, RoomId = 6, StartTime = DateTime.Now.AddDays(7)
                },
                new Viewing
                {
                    ViewingId = 35, MovieId = 2, RoomId = 1, StartTime = DateTime.Now.AddDays(7).AddHours(1)
                },
                new Viewing
                {
                    ViewingId = 36, MovieId = 3, RoomId = 2, StartTime = DateTime.Now.AddDays(7).AddHours(3)
                },
                new Viewing
                {
                    ViewingId = 37, MovieId = 4, RoomId = 4, StartTime = DateTime.Now.AddDays(7).AddHours(2)
                },
                new Viewing
                {
                    ViewingId = 44, MovieId = 9, RoomId = 3, StartTime = DateTime.Now.AddDays(7).AddHours(4)
                },
                new Viewing
                {
                    ViewingId = 45, MovieId = 6, RoomId = 5, StartTime = DateTime.Now.AddDays(7).AddHours(4)
                }
            };

            //context.Rate.AddOrUpdate(
            //    new Rate { RateId = 1, Name = "Normaal", Price = 8.50 },
            //    new Rate { RateId = 2, Name = "Normaal (Langer dan 120 minuten)", Price = 9.00 },
            //    new Rate { RateId = 3, Name = "Kinderkorting", Price = 7.00 },
            //    new Rate { RateId = 4, Name = "Studentenkorting", Price = 7.00 },
            //    new Rate { RateId = 5, Name = "65+ reductie", Price = 7.00 },
            //    new Rate { RateId = 6, Name = "3D Film", Price = 2.50 }

            //);

            List<Ticket> ticketList = new List<Ticket>
            {
                new Ticket { TicketId = 1, RateId = 2, SeatId = 241, ViewingId = 1, OrderNumber = 1 },
                new Ticket { TicketId = 2, RateId = 2, SeatId = 242, ViewingId = 1, OrderNumber = 1 },
                new Ticket { TicketId = 3, RateId = 2, SeatId = 243, ViewingId = 1, OrderNumber = 1 }
            };

            List<Ticket> ticketList2 = new List<Ticket>
            {
                new Ticket { TicketId = 4, RateId = 2, SeatId = 1, ViewingId = 2, OrderNumber = 2 },
                new Ticket { TicketId = 5, RateId = 2, SeatId = 2, ViewingId = 2, OrderNumber = 2 }

            };
            context.Order.AddOrUpdate(
                new Order { OrderId = 1, Tickets = ticketList },
                new Order { OrderId = 2, Tickets = ticketList2 }
            );

            //NewsLetters
            newsLetterList.ForEach(s => context.NewsLetter.AddOrUpdate(s));

            //Genres
            genreList.ForEach(s => context.Genre.AddOrUpdate(s));

            //Movies
            movieList.ForEach(s => context.Movie.AddOrUpdate(s));

            //Rows
            rowListZaal1.ForEach(s => context.Row.AddOrUpdate(s));

            rowListZaal2.ForEach(s => context.Row.AddOrUpdate(s));

            rowListZaal3.ForEach(s => context.Row.AddOrUpdate(s));

            //Rooms
            roomList.ForEach(s => context.Room.AddOrUpdate(s));

            //Viewings
            viewingList.ForEach(s => context.Viewing.AddOrUpdate(s));
            context.SaveChanges();

        }
    }
}
