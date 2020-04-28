insert into Products (Name_en, Name_sk, Type, Description_sk, Description_en, Image, CategoryId) 
values 
	('Balancing machine of grinding wheels','Vyvažovačka brusných kotúčov','Hofmann EO-RE','','','3742058904c2c49940aebf.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('HBM','Vodorovná vyvrtávačka','WH 10','s odmeriavanim','','163184395858ad7d52cb4ad.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Lathe','Sústruh hrotový','SUI 40/2000','','','15316207935ddd2faaac64b.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Radial drill machine','Vŕtačka radiálna','VR4','','','8715704985e7b3002679ac.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Grinder for holes','Brúska na otvory','Si 125x175','','','9305022325b3202747c9ea.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Milling machine','Frézka vertikálna','FA 4 V','','','12960809965acf28493ef0d.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Karusel','Karusel','SK 12','','','6979155425e5f87767034f.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Universal centre grinding','Brúska hrotová univerzálna','BUAJ 28','','','17614582205e7b30ff895b6.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Cylindrical grinding ','Brúska hrotová','BHU 32 A/1000','','','6577544675e7b316fd733c.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Double disc grinding ','Brúska rovinná dvojkotúčová','BRD 60','','','16998023395e7b33228a3c9.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Universal lathe','Sústruh hrotový','SN 55 C/1500','','','8123970565e5f84eecb0e9.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Surface grinding machine','Brúska rovinná','BLOHM HFS 9','Max. width of grinding  400 mm Max. length of grinding 900 mm','','16500660935a155d042b44a.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Lathe','Sústruh','SN 63 B/1500','','','15467558025d09ebde5547c.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Lathe','Sústruh','SV 18 RA/1000','','','19211395215d09ec7ca02de.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Radial drill machine','Vŕtačka radiálna','VR 6 A/1700','','','643252124557ea52679e2f.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Thread grinder','Brúska na závity','5822 M','','','9775489885d09e047b741b.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Radial drill machine','Vŕtačka radiálna','VR 8 A','','','106132115658ad7e03b7988.jpg',(select id from Categories where Name_en = 'Metalworking machines')),
	('Lathe','Sústruh hrotový','SN 55/4000','with 2 pcs fixed steady','','13004510565e3030e2d3efd.jpg',(select id from Categories where Name_en = 'Metalworking machines')),

	('Rolling machine','Valcovačka závitov','GWR 80','','','4997877165ddd2ff643816.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Punching machine','Vysekávací stríhaci stroj ','MULTI 70','','vysekávací, stríhací stroj, uhlové strihanie, strihanie guľatiny','14694256524bb47aafbe449.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Thread rolling machine','Valcovačka závitov','UPW 25.1','','','8981281025e7b2f1591ed3.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Thread rolling machine','Valcovačka závitov','UPW 6,3x40','','','8262151555e7b2faa83dd1.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Plate for press LEK 160','Stolná doska k lisu LEK 160','LEK 160','1000x740 mm','1000x740 mm','11897868464f7575fcddd1b.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Planing machine','Hoblovka','HD 12,5','table 22800x1400 mm','22800x1400 mm','14843590105e5f867039c9f.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Bending machine','Ohýbačka plechu','CIDAN K 25-20','2020/3 mm','2020/3 mm','34816924058ad8e262bb2d.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Eccentric press ','Výstredníkový lis ','LENA 40 C','','','66866278541159f859115.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Table shears','Tabuľové nožnice','CNTA 3150/10','','','9771800875d09e9d6e86f8.jpg',(select id from Categories where Name_en = 'Forming machines')),
	('Table shears','Tabuľové nožnice','CNTA 3150/16','','','7596355475d09ea870c3fc.jpg',(select id from Categories where Name_en = 'Forming machines')),

	('Vertical shaping machine','Zvislá obrážačka','ST 350','','','4065487844a92854855720.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Gear shapping machine','Frézka na ozubenie','Gleason 106','','','12970183525b5856d0c503f.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Shaping machine','Zvislá obrázačka','7A412','','','21094003545e7b32257faea.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Shaping machine','Vodorovná obrázačka','GH 400','','','13736097085e7b32d6ce3dd.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Gear hobbing machine PFAUTER','Frézka odvaľovacia PFAUTER','RS 40','','','678543156531d85438b129.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Shaping machine','Vodorovná obrážačka','SH 700 A','Table 700x400 mm','Table 700x400 mm','160652901853204185b957e.jpg',(select id from Categories where Name_en = 'Gear machines')),
	('Gear hobbing machine','Odvaľovacia frézka','OFA 71 A','','','494961667579f13917ea68.jpg',(select id from Categories where Name_en = 'Gear machines')),

	('Gear spline rollers','Stroj na drážkové hriadele','ZRM 9','','','4144982225e7b356db312c.jpg',(select id from Categories where Name_en = 'Other machines')),
	('Floor plates','Montážne dosky','1300x1300','','','20034697025141b39c60afd.jpg',(select id from Categories where Name_en = 'Other machines')),
	('Floor plates','Montážne dosky','','dimension 1300x1300 mm 4 pcs 1500x1500 mm 4 pcs','','379737055519c8dc0316ae.jpg',(select id from Categories where Name_en = 'Other machines')),

	('Milling tools','Frézy','','','','1911864050555d9fa97d44c.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Steady','Luneta k brúske','','','','1201485325555da02712689.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Tassler of grinding wheels','Orezávač brúsnych kotúčov','','','','1784421131555da428a5446.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Grinding wheels','Brúsne kotúče','','','','853235450555daa37b56eb.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Support bearing for milling machine','Operné ložisko k frézke FGS 32','','','','1301340172555daad02e0eb.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Equipment','Príslušenstvo k strojom','','','','643083044555dabdc724f3.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Machine vice','Zverák','','','','534254044555dac62ced49.jpg',(select id from Categories where Name_en = 'Accessories')),
	('Equipment','Príslušenstvo k strojom','','','','872571140555dadfa02d9b.jpg',(select id from Categories where Name_en = 'Accessories'));




