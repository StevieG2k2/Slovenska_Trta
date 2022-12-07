using web.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TrtaContext context)
        {
            // Look for any vinogradi.
            if (context.Vinogradi.Any())
            {
                return;   // DB has been seeded
            }

			// ###############################
			// SKUPAJ = 1, BELO = 2, RDEČE = 3
			// ###############################
			var trte = new Trte[]
            {
                new Trte{Sorta="Skupaj"},
                new Trte{Sorta="Belo"},
                new Trte{Sorta="Rdeče"}
            };

            context.Trte.AddRange(trte);
            context.SaveChanges();

            var vinogradi = new Vinogradi[]
            {
                new Vinogradi{TrteId=1,Povrsina=16735,StTrt=42646,letoMeritve=1991},
                new Vinogradi{TrteId=2,Povrsina=12726,StTrt=32643,letoMeritve=1991},
                new Vinogradi{TrteId=3,Povrsina=4010,StTrt=10003,letoMeritve=1991},
				
				new Vinogradi{TrteId=1,Povrsina=16797,StTrt=59001,letoMeritve=1992},
                new Vinogradi{TrteId=2,Povrsina=12763,StTrt=44866,letoMeritve=1992},
                new Vinogradi{TrteId=3,Povrsina=4034,StTrt=14134,letoMeritve=1992},
				
				new Vinogradi{TrteId=1,Povrsina=16749,StTrt=58265,letoMeritve=1993},
                new Vinogradi{TrteId=2,Povrsina=12703,StTrt=44279,letoMeritve=1993},
                new Vinogradi{TrteId=3,Povrsina=4046,StTrt=13986,letoMeritve=1993},
				
				new Vinogradi{TrteId=1,Povrsina=17184,StTrt=57277,letoMeritve=1994},
                new Vinogradi{TrteId=2,Povrsina=13015,StTrt=43528,letoMeritve=1994},
                new Vinogradi{TrteId=3,Povrsina=4169,StTrt=13749,letoMeritve=1994},
				
				new Vinogradi{TrteId=1,Povrsina=17502,StTrt=57625,letoMeritve=1995},
                new Vinogradi{TrteId=2,Povrsina=13236,StTrt=43750,letoMeritve=1995},
                new Vinogradi{TrteId=3,Povrsina=4266,StTrt=13875,letoMeritve=1995},
				
				new Vinogradi{TrteId=1,Povrsina=17736,StTrt=56686,letoMeritve=1996},
                new Vinogradi{TrteId=2,Povrsina=13227,StTrt=42680,letoMeritve=1996},
                new Vinogradi{TrteId=3,Povrsina=4509,StTrt=14005,letoMeritve=1996},
				
				new Vinogradi{TrteId=1,Povrsina=17420,StTrt=55863,letoMeritve=1997},
                new Vinogradi{TrteId=2,Povrsina=13000,StTrt=42103,letoMeritve=1997},
                new Vinogradi{TrteId=3,Povrsina=4420,StTrt=13760,letoMeritve=1997},
				
				new Vinogradi{TrteId=1,Povrsina=17388,StTrt=56207,letoMeritve=1998},
                new Vinogradi{TrteId=2,Povrsina=12975,StTrt=42377,letoMeritve=1998},
                new Vinogradi{TrteId=3,Povrsina=4413,StTrt=13831,letoMeritve=1998},
				
				new Vinogradi{TrteId=1,Povrsina=16591,StTrt=49037,letoMeritve=1999},
                new Vinogradi{TrteId=2,Povrsina=12094,StTrt=36501,letoMeritve=1999},
                new Vinogradi{TrteId=3,Povrsina=4497,StTrt=12536,letoMeritve=1999},
				
				new Vinogradi{TrteId=1,Povrsina=16602,StTrt=53186,letoMeritve=2000},
                new Vinogradi{TrteId=2,Povrsina=12280,StTrt=40227,letoMeritve=2000},
                new Vinogradi{TrteId=3,Povrsina=4322,StTrt=12959,letoMeritve=2000},
				
				new Vinogradi{TrteId=1,Povrsina=16602,StTrt=53186,letoMeritve=2001},
                new Vinogradi{TrteId=2,Povrsina=12280,StTrt=40227,letoMeritve=2001},
                new Vinogradi{TrteId=3,Povrsina=4322,StTrt=12959,letoMeritve=2001},
				
				new Vinogradi{TrteId=1,Povrsina=16602,StTrt=53186,letoMeritve=2002},
                new Vinogradi{TrteId=2,Povrsina=12280,StTrt=40227,letoMeritve=2002},
                new Vinogradi{TrteId=3,Povrsina=4322,StTrt=12959,letoMeritve=2002},
				
				new Vinogradi{TrteId=1,Povrsina=16556,StTrt=54698,letoMeritve=2003},
                new Vinogradi{TrteId=2,Povrsina=11957,StTrt=40103,letoMeritve=2003},
                new Vinogradi{TrteId=3,Povrsina=4599,StTrt=14595,letoMeritve=2003},
				
				new Vinogradi{TrteId=1,Povrsina=16556,StTrt=54698,letoMeritve=2004},
                new Vinogradi{TrteId=2,Povrsina=11957,StTrt=40103,letoMeritve=2004},
                new Vinogradi{TrteId=3,Povrsina=4599,StTrt=14595,letoMeritve=2004},
				
				new Vinogradi{TrteId=1,Povrsina=16428,StTrt=53895,letoMeritve=2005},
                new Vinogradi{TrteId=2,Povrsina=11511,StTrt=38354,letoMeritve=2005},
                new Vinogradi{TrteId=3,Povrsina=4916,StTrt=15542,letoMeritve=2005},
				
				new Vinogradi{TrteId=1,Povrsina=16428,StTrt=53895,letoMeritve=2006},
                new Vinogradi{TrteId=2,Povrsina=11511,StTrt=38354,letoMeritve=2006},
                new Vinogradi{TrteId=3,Povrsina=4916,StTrt=15542,letoMeritve=2006},
				
				new Vinogradi{TrteId=1,Povrsina=16086,StTrt=55126,letoMeritve=2007},
                new Vinogradi{TrteId=2,Povrsina=10715,StTrt=37011,letoMeritve=2007},
                new Vinogradi{TrteId=3,Povrsina=5371,StTrt=18115,letoMeritve=2007},
				
				new Vinogradi{TrteId=1,Povrsina=16086,StTrt=55126,letoMeritve=2008},
                new Vinogradi{TrteId=2,Povrsina=10715,StTrt=37011,letoMeritve=2008},
                new Vinogradi{TrteId=3,Povrsina=5371,StTrt=18115,letoMeritve=2008},
				
				new Vinogradi{TrteId=1,Povrsina=16086,StTrt=55126,letoMeritve=2009},
                new Vinogradi{TrteId=2,Povrsina=10715,StTrt=37011,letoMeritve=2009},
                new Vinogradi{TrteId=3,Povrsina=5371,StTrt=18115,letoMeritve=2009},
				
				new Vinogradi{TrteId=1,Povrsina=16351,StTrt=57093,letoMeritve=2010},
                new Vinogradi{TrteId=2,Povrsina=11246,StTrt=39687,letoMeritve=2010},
                new Vinogradi{TrteId=3,Povrsina=5105,StTrt=17406,letoMeritve=2010},
				
				new Vinogradi{TrteId=1,Povrsina=16351,StTrt=57093,letoMeritve=2011},
                new Vinogradi{TrteId=2,Povrsina=11246,StTrt=39687,letoMeritve=2011},
                new Vinogradi{TrteId=3,Povrsina=5105,StTrt=17406,letoMeritve=2011},
				
				new Vinogradi{TrteId=1,Povrsina=16351,StTrt=57093,letoMeritve=2012},
                new Vinogradi{TrteId=2,Povrsina=11246,StTrt=39687,letoMeritve=2012},
                new Vinogradi{TrteId=3,Povrsina=5105,StTrt=17406,letoMeritve=2012},
				
				new Vinogradi{TrteId=1,Povrsina=16085,StTrt=60362,letoMeritve=2013},
                new Vinogradi{TrteId=2,Povrsina=11086,StTrt=41905,letoMeritve=2013},
                new Vinogradi{TrteId=3,Povrsina=4999,StTrt=18457,letoMeritve=2013},
				
				new Vinogradi{TrteId=1,Povrsina=16009,StTrt=60553,letoMeritve=2014},
                new Vinogradi{TrteId=2,Povrsina=11033,StTrt=42038,letoMeritve=2014},
                new Vinogradi{TrteId=3,Povrsina=4976,StTrt=18515,letoMeritve=2014},
				
				new Vinogradi{TrteId=1,Povrsina=15692,StTrt=59914,letoMeritve=2015},
                new Vinogradi{TrteId=2,Povrsina=10794,StTrt=41514,letoMeritve=2015},
                new Vinogradi{TrteId=3,Povrsina=4898,StTrt=18400,letoMeritve=2015},
				
				new Vinogradi{TrteId=1,Povrsina=15824,StTrt=60740,letoMeritve=2016},
                new Vinogradi{TrteId=2,Povrsina=10889,StTrt=42053,letoMeritve=2016},
                new Vinogradi{TrteId=3,Povrsina=4935,StTrt=18687,letoMeritve=2016},
				
				new Vinogradi{TrteId=1,Povrsina=15839,StTrt=61147,letoMeritve=2017},
                new Vinogradi{TrteId=2,Povrsina=10895,StTrt=42312,letoMeritve=2017},
                new Vinogradi{TrteId=3,Povrsina=4944,StTrt=18835,letoMeritve=2017},
				
				new Vinogradi{TrteId=1,Povrsina=15630,StTrt=60910,letoMeritve=2018},
                new Vinogradi{TrteId=2,Povrsina=10827,StTrt=42286,letoMeritve=2018},
                new Vinogradi{TrteId=3,Povrsina=4803,StTrt=18624,letoMeritve=2018},
				
				new Vinogradi{TrteId=1,Povrsina=15549,StTrt=60884,letoMeritve=2019},
                new Vinogradi{TrteId=2,Povrsina=10777,StTrt=42325,letoMeritve=2019},
                new Vinogradi{TrteId=3,Povrsina=4772,StTrt=18560,letoMeritve=2019},
				
				new Vinogradi{TrteId=1,Povrsina=15265,StTrt=59857,letoMeritve=2020},
                new Vinogradi{TrteId=2,Povrsina=10599,StTrt=41603,letoMeritve=2020},
                new Vinogradi{TrteId=3,Povrsina=4666,StTrt=18254,letoMeritve=2020},
				
				new Vinogradi{TrteId=1,Povrsina=14874,StTrt=58527,letoMeritve=2021},
                new Vinogradi{TrteId=2,Povrsina=10327,StTrt=40635,letoMeritve=2021},
                new Vinogradi{TrteId=3,Povrsina=4547,StTrt=17892,letoMeritve=2021}
            };

            context.Vinogradi.AddRange(vinogradi);
            context.SaveChanges();
			
			var pridelek = new Pridelek[]
            {
                new Pridelek{TrteId=1,VinogradId=1,Kolicina=108141,KolNaHa=6.5M,KgNaTrto=2.5M,letoMeritve=1991},
                new Pridelek{TrteId=2,VinogradId=2,Kolicina=81255,KolNaHa=6.4M,KgNaTrto=2.5M,letoMeritve=1991},
                new Pridelek{TrteId=3,VinogradId=3,Kolicina=26886,KolNaHa=6.7M,KgNaTrto=2.7M,letoMeritve=1991},
				
				new Pridelek{TrteId=1,VinogradId=4,Kolicina=124011,KolNaHa=7.4M,KgNaTrto=2.1M,letoMeritve=1992},
                new Pridelek{TrteId=2,VinogradId=5,Kolicina=93253,KolNaHa=7.3M,KgNaTrto=2.1M,letoMeritve=1992},
                new Pridelek{TrteId=3,VinogradId=6,Kolicina=30758,KolNaHa=7.6M,KgNaTrto=2.2M,letoMeritve=1992},
				
				new Pridelek{TrteId=1,VinogradId=7,Kolicina=128343,KolNaHa=7.7M,KgNaTrto=2.2M,letoMeritve=1993},
                new Pridelek{TrteId=2,VinogradId=8,Kolicina=96337,KolNaHa=7.6M,KgNaTrto=2.2M,letoMeritve=1993},
                new Pridelek{TrteId=3,VinogradId=9,Kolicina=32006,KolNaHa=7.9M,KgNaTrto=2.3M,letoMeritve=1993},
				
				new Pridelek{TrteId=1,VinogradId=10,Kolicina=109197,KolNaHa=6.4M,KgNaTrto=1.9M,letoMeritve=1994},
                new Pridelek{TrteId=2,VinogradId=11,Kolicina=82113,KolNaHa=6.3M,KgNaTrto=1.9M,letoMeritve=1994},
                new Pridelek{TrteId=3,VinogradId=12,Kolicina=27084,KolNaHa=6.5M,KgNaTrto=2.0M,letoMeritve=1994},
				
				new Pridelek{TrteId=1,VinogradId=13,Kolicina=87075,KolNaHa=5.0M,KgNaTrto=1.5M,letoMeritve=1995},
                new Pridelek{TrteId=2,VinogradId=14,Kolicina=65533,KolNaHa=5.0M,KgNaTrto=1.5M,letoMeritve=1995},
                new Pridelek{TrteId=3,VinogradId=15,Kolicina=21542,KolNaHa=5.1M,KgNaTrto=1.6M,letoMeritve=1995},
				
				new Pridelek{TrteId=1,VinogradId=16,Kolicina=114675,KolNaHa=6.5M,KgNaTrto=2.0M,letoMeritve=1996},
                new Pridelek{TrteId=2,VinogradId=17,Kolicina=84798,KolNaHa=6.4M,KgNaTrto=2.0M,letoMeritve=1996},
                new Pridelek{TrteId=3,VinogradId=18,Kolicina=29877,KolNaHa=6.6M,KgNaTrto=2.1M,letoMeritve=1996},
				
				new Pridelek{TrteId=1,VinogradId=19,Kolicina=127736,KolNaHa=7.3M,KgNaTrto=2.3M,letoMeritve=1997},
                new Pridelek{TrteId=2,VinogradId=20,Kolicina=100949,KolNaHa=7.8M,KgNaTrto=2.4M,letoMeritve=1997},
                new Pridelek{TrteId=3,VinogradId=21,Kolicina=26787,KolNaHa=6.1M,KgNaTrto=2.0M,letoMeritve=1997},
				
				new Pridelek{TrteId=1,VinogradId=22,Kolicina=122677,KolNaHa=7.1M,KgNaTrto=2.2M,letoMeritve=1998},
                new Pridelek{TrteId=2,VinogradId=23,Kolicina=92508,KolNaHa=7.1M,KgNaTrto=2.2M,letoMeritve=1998},
                new Pridelek{TrteId=3,VinogradId=24,Kolicina=30169,KolNaHa=6.8M,KgNaTrto=2.2M,letoMeritve=1998},
				
				new Pridelek{TrteId=1,VinogradId=25,Kolicina=98334,KolNaHa=5.9M,KgNaTrto=2.0M,letoMeritve=1999},
                new Pridelek{TrteId=2,VinogradId=26,Kolicina=73634,KolNaHa=6.1M,KgNaTrto=2.0M,letoMeritve=1999},
                new Pridelek{TrteId=3,VinogradId=27,Kolicina=24700,KolNaHa=5.5M,KgNaTrto=2.0M,letoMeritve=1999},
				
				new Pridelek{TrteId=1,VinogradId=28,Kolicina=126650,KolNaHa=7.6M,KgNaTrto=2.4M,letoMeritve=2000},
                new Pridelek{TrteId=2,VinogradId=29,Kolicina=96079,KolNaHa=7.8M,KgNaTrto=2.4M,letoMeritve=2000},
                new Pridelek{TrteId=3,VinogradId=30,Kolicina=30571,KolNaHa=7.1M,KgNaTrto=2.4M,letoMeritve=2000},
				
				new Pridelek{TrteId=1,VinogradId=31,Kolicina=106633,KolNaHa=6.4M,KgNaTrto=2.0M,letoMeritve=2001},
                new Pridelek{TrteId=2,VinogradId=32,Kolicina=79422,KolNaHa=6.5M,KgNaTrto=2.0M,letoMeritve=2001},
                new Pridelek{TrteId=3,VinogradId=33,Kolicina=27211,KolNaHa=6.3M,KgNaTrto=2.1M,letoMeritve=2001},
				
				new Pridelek{TrteId=1,VinogradId=34,Kolicina=122985,KolNaHa=7.4M,KgNaTrto=2.3M,letoMeritve=2002},
                new Pridelek{TrteId=2,VinogradId=35,Kolicina=92375,KolNaHa=7.5M,KgNaTrto=2.3M,letoMeritve=2002},
                new Pridelek{TrteId=3,VinogradId=36,Kolicina=30610,KolNaHa=7.1M,KgNaTrto=2.4M,letoMeritve=2002},
				
				new Pridelek{TrteId=1,VinogradId=37,Kolicina=104394,KolNaHa=6.3M,KgNaTrto=1.6M,letoMeritve=2003},
                new Pridelek{TrteId=2,VinogradId=38,Kolicina=79209,KolNaHa=6.6M,KgNaTrto=1.6M,letoMeritve=2003},
                new Pridelek{TrteId=3,VinogradId=39,Kolicina=25185,KolNaHa=5.5M,KgNaTrto=1.4M,letoMeritve=2003},
				
				new Pridelek{TrteId=1,VinogradId=40,Kolicina=134792,KolNaHa=8.1M,KgNaTrto=2.5M,letoMeritve=2004},
                new Pridelek{TrteId=2,VinogradId=41,Kolicina=95484,KolNaHa=8.0M,KgNaTrto=2.4M,letoMeritve=2004},
                new Pridelek{TrteId=3,VinogradId=42,Kolicina=39308,KolNaHa=8.5M,KgNaTrto=2.7M,letoMeritve=2004},
				
				new Pridelek{TrteId=1,VinogradId=43,Kolicina=120868,KolNaHa=7.4M,KgNaTrto=2.2M,letoMeritve=2005},
                new Pridelek{TrteId=2,VinogradId=44,Kolicina=81590,KolNaHa=7.1M,KgNaTrto=2.1M,letoMeritve=2005},
                new Pridelek{TrteId=3,VinogradId=45,Kolicina=39278,KolNaHa=8.0M,KgNaTrto=2.5M,letoMeritve=2005},
				
				new Pridelek{TrteId=1,VinogradId=46,Kolicina=105486,KolNaHa=6.4M,KgNaTrto=2.0M,letoMeritve=2006},
                new Pridelek{TrteId=2,VinogradId=47,Kolicina=73246,KolNaHa=6.4M,KgNaTrto=1.9M,letoMeritve=2006},
                new Pridelek{TrteId=3,VinogradId=48,Kolicina=32240,KolNaHa=6.6M,KgNaTrto=2.1M,letoMeritve=2006},
				
				new Pridelek{TrteId=1,VinogradId=49,Kolicina=122543,KolNaHa=7.6M,KgNaTrto=2.2M,letoMeritve=2007},
                new Pridelek{TrteId=2,VinogradId=50,Kolicina=82354,KolNaHa=7.7M,KgNaTrto=2.2M,letoMeritve=2007},
                new Pridelek{TrteId=3,VinogradId=51,Kolicina=40189,KolNaHa=7.5M,KgNaTrto=2.2M,letoMeritve=2007},
				
				new Pridelek{TrteId=1,VinogradId=52,Kolicina=105719,KolNaHa=6.6M,KgNaTrto=1.9M,letoMeritve=2008},
                new Pridelek{TrteId=2,VinogradId=53,Kolicina=69823,KolNaHa=6.5M,KgNaTrto=1.9M,letoMeritve=2008},
                new Pridelek{TrteId=3,VinogradId=54,Kolicina=35896,KolNaHa=6.7M,KgNaTrto=2.0M,letoMeritve=2008},
				
				new Pridelek{TrteId=1,VinogradId=55,Kolicina=112855,KolNaHa=7.0M,KgNaTrto=2.0M,letoMeritve=2009},
                new Pridelek{TrteId=2,VinogradId=56,Kolicina=71273,KolNaHa=6.7M,KgNaTrto=1.9M,letoMeritve=2009},
                new Pridelek{TrteId=3,VinogradId=57,Kolicina=41582,KolNaHa=7.6M,KgNaTrto=2.3M,letoMeritve=2009},
				
				new Pridelek{TrteId=1,VinogradId=58,Kolicina=108541,KolNaHa=6.6M,KgNaTrto=1.9M,letoMeritve=2010},
                new Pridelek{TrteId=2,VinogradId=59,Kolicina=74062,KolNaHa=6.6M,KgNaTrto=1.9M,letoMeritve=2010},
                new Pridelek{TrteId=3,VinogradId=60,Kolicina=34479,KolNaHa=6.8M,KgNaTrto=2.0M,letoMeritve=2010},
				
				new Pridelek{TrteId=1,VinogradId=61,Kolicina=121396,KolNaHa=7.4M,KgNaTrto=2.1M,letoMeritve=2011},
                new Pridelek{TrteId=2,VinogradId=62,Kolicina=84850,KolNaHa=7.5M,KgNaTrto=2.1M,letoMeritve=2011},
                new Pridelek{TrteId=3,VinogradId=63,Kolicina=36546,KolNaHa=7.2M,KgNaTrto=2.1M,letoMeritve=2011},
				
				new Pridelek{TrteId=1,VinogradId=64,Kolicina=92324,KolNaHa=5.6M,KgNaTrto=1.6M,letoMeritve=2012},
                new Pridelek{TrteId=2,VinogradId=65,Kolicina=65182,KolNaHa=5.8M,KgNaTrto=1.6M,letoMeritve=2012},
                new Pridelek{TrteId=3,VinogradId=66,Kolicina=27141,KolNaHa=5.3M,KgNaTrto=1.6M,letoMeritve=2012},
			
				new Pridelek{TrteId=1,VinogradId=67,Kolicina=100177,KolNaHa=6.2M,KgNaTrto=1.7M,letoMeritve=2013},
                new Pridelek{TrteId=2,VinogradId=68,Kolicina=68378,KolNaHa=6.2M,KgNaTrto=1.6M,letoMeritve=2013},
                new Pridelek{TrteId=3,VinogradId=69,Kolicina=31799,KolNaHa=6.4M,KgNaTrto=1.7M,letoMeritve=2013},
				
				new Pridelek{TrteId=1,VinogradId=70,Kolicina=94209,KolNaHa=5.9M,KgNaTrto=1.6M,letoMeritve=2014},
                new Pridelek{TrteId=2,VinogradId=71,Kolicina=65122,KolNaHa=5.9M,KgNaTrto=1.5M,letoMeritve=2014},
                new Pridelek{TrteId=3,VinogradId=72,Kolicina=29087,KolNaHa=5.8M,KgNaTrto=1.6M,letoMeritve=2014},
				
				new Pridelek{TrteId=1,VinogradId=73,Kolicina=117585,KolNaHa=7.5M,KgNaTrto=2.0M,letoMeritve=2015},
                new Pridelek{TrteId=2,VinogradId=74,Kolicina=81268,KolNaHa=7.5M,KgNaTrto=2.0M,letoMeritve=2015},
                new Pridelek{TrteId=3,VinogradId=75,Kolicina=36318,KolNaHa=7.4M,KgNaTrto=2.0M,letoMeritve=2015},
				
				new Pridelek{TrteId=1,VinogradId=76,Kolicina=94780,KolNaHa=6.0M,KgNaTrto=1.6M,letoMeritve=2016},
                new Pridelek{TrteId=2,VinogradId=77,Kolicina=63765,KolNaHa=5.9M,KgNaTrto=1.5M,letoMeritve=2016},
                new Pridelek{TrteId=3,VinogradId=78,Kolicina=31015,KolNaHa=6.3M,KgNaTrto=1.7M,letoMeritve=2016},
				
				new Pridelek{TrteId=1,VinogradId=79,Kolicina=89416,KolNaHa=5.6M,KgNaTrto=1.5M,letoMeritve=2017},
                new Pridelek{TrteId=2,VinogradId=80,Kolicina=63272,KolNaHa=5.8M,KgNaTrto=1.5M,letoMeritve=2017},
                new Pridelek{TrteId=3,VinogradId=81,Kolicina=26144,KolNaHa=5.3M,KgNaTrto=1.4M,letoMeritve=2017},
				
				new Pridelek{TrteId=1,VinogradId=82,Kolicina=126958,KolNaHa=8.1M,KgNaTrto=2.1M,letoMeritve=2018},
                new Pridelek{TrteId=2,VinogradId=83,Kolicina=86569,KolNaHa=8.0M,KgNaTrto=2.0M,letoMeritve=2018},
                new Pridelek{TrteId=3,VinogradId=84,Kolicina=40389,KolNaHa=8.4M,KgNaTrto=2.2M,letoMeritve=2018},
				
				new Pridelek{TrteId=1,VinogradId=85,Kolicina=105035,KolNaHa=6.8M,KgNaTrto=1.7M,letoMeritve=2019},
                new Pridelek{TrteId=2,VinogradId=86,Kolicina=74114,KolNaHa=6.9M,KgNaTrto=1.8M,letoMeritve=2019},
                new Pridelek{TrteId=3,VinogradId=87,Kolicina=30921,KolNaHa=6.5M,KgNaTrto=1.7M,letoMeritve=2019},
				
				new Pridelek{TrteId=1,VinogradId=88,Kolicina=103637,KolNaHa=6.8M,KgNaTrto=1.7M,letoMeritve=2020},
                new Pridelek{TrteId=2,VinogradId=89,Kolicina=74349,KolNaHa=7.0M,KgNaTrto=1.8M,letoMeritve=2020},
                new Pridelek{TrteId=3,VinogradId=90,Kolicina=29288,KolNaHa=6.3M,KgNaTrto=1.6M,letoMeritve=2020},
				
				new Pridelek{TrteId=1,VinogradId=91,Kolicina=84158,KolNaHa=5.7M,KgNaTrto=1.4M,letoMeritve=2021},
                new Pridelek{TrteId=2,VinogradId=92,Kolicina=61169,KolNaHa=5.9M,KgNaTrto=1.5M,letoMeritve=2021},
                new Pridelek{TrteId=3,VinogradId=93,Kolicina=22990,KolNaHa=5.1M,KgNaTrto=1.3M,letoMeritve=2021}
            };

            context.Pridelek.AddRange(pridelek);
            context.SaveChanges();
			
			var odkup = new Odkup[]
            {
                new Odkup{PridelekId=67,Kolicina=15233,CenaNaKg=0.46M,letoMeritve=2013},
                new Odkup{PridelekId=70,Kolicina=14393,CenaNaKg=0.46M,letoMeritve=2014},
                new Odkup{PridelekId=73,Kolicina=15287,CenaNaKg=0.5M,letoMeritve=2015},
                new Odkup{PridelekId=76,Kolicina=12310,CenaNaKg=0.55M,letoMeritve=2016},
                new Odkup{PridelekId=79,Kolicina=17005,CenaNaKg=0.6M,letoMeritve=2017},
                new Odkup{PridelekId=82,Kolicina=24553,CenaNaKg=0.57M,letoMeritve=2018},
                new Odkup{PridelekId=85,Kolicina=16981,CenaNaKg=0.6M,letoMeritve=2019},
                new Odkup{PridelekId=88,Kolicina=15918,CenaNaKg=0.49M,letoMeritve=2020},
                new Odkup{PridelekId=91,Kolicina=14991,CenaNaKg=0.57M,letoMeritve=2021},
            };

            context.Odkup.AddRange(odkup);

            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"}
            };

            foreach(IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            var user = new ApplicationUser
            {
                FirstName = "Janez",
                LastName = "Selski",
                City = "Ljubljana",
                Email = "janezselski@gmail.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user,"Geslo123&");
                user.PasswordHash = hashed;
                context.Users.Add(user);
                
            }

            context.SaveChanges();
            

            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }

            context.SaveChanges();
        }
    }
}