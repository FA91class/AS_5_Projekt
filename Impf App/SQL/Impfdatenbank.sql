CREATE DATABASE IF NOT EXISTS Impfdatenbank;
USE Impfdatenbank;

DROP TABLE IF EXISTS T_Impfdosen;
DROP TABLE IF EXISTS T_Impfstoffe;
DROP TABLE IF EXISTS T_Patienten;
DROP TABLE IF EXISTS T_Krankenkassen;

CREATE TABLE T_Krankenkassen
(
    P_Krankenkassen_ID CHAR(20) NOT NULL,
    Bezeichnung CHAR(50),
    Strasse_HausNr CHAR(50),
    PLZ CHAR(5),
    Ort CHAR(30)
);

ALTER TABLE T_Krankenkassen
ADD CONSTRAINT PK_Krankenkassen PRIMARY KEY (P_Krankenkassen_ID);

INSERT INTO T_Krankenkassen
VALUES ('106415300', 'AOK Nordost - Die Gesundheitskasse', NULL, '14456', 'Potsdam');
INSERT INTO T_Krankenkassen
VALUES ('45454764', 'KKH Kaufmännische Krankenkasse', 'Karl-Wiechert-Allee 61', '30625', 'Hannover');
INSERT INTO T_Krankenkassen
VALUES ('876508954', 'TK Techniker Krankenkasse', 'Bramfelder Str. 140', '22305', 'Hamburg');
INSERT INTO T_Krankenkassen
VALUES ('028983434523', 'IKK Brandenburg und Berlin', 'Postfach 90 02 51', '14438', 'Potsdam');
INSERT INTO T_Krankenkassen
VALUES ('564565687', 'DAK-Gesundheit', 'Nagelsweg 27 -31', '20097', 'Hamburg');
INSERT INTO T_Krankenkassen
VALUES ('134356720', 'BARMER GEK', 'Axel-Springer-Straße 44', '10969', 'Berlin');
INSERT INTO T_Krankenkassen
VALUES ('1637852973', 'BKK Melitta Plus', 'Marienstr. 122', '32425', 'Minden');

CREATE TABLE T_Patienten
(
    P_Versicherungsnr CHAR(20) NOT NULL,
    PF_Krankenkasse CHAR(20),
    Geschlecht CHAR,
    Nachname CHAR(30),
    Vorname CHAR(30),
    GebDat DATETIME,
    Strasse_HausNr CHAR(30),
    PLZ CHAR(5),
    Ort CHAR(30)
);

ALTER TABLE T_Patienten
ADD CONSTRAINT PK_Patienten PRIMARY KEY (P_Versicherungsnr, PF_Krankenkasse);
ALTER TABLE T_Patienten
ADD CONSTRAINT FK_Patienten_zu_Krankenkassen FOREIGN KEY (PF_Krankenkasse) REFERENCES T_Krankenkassen (P_Krankenkassen_ID);

-- INSERT Patienten
-- ================
INSERT INTO T_Patienten
VALUES ('123', '106415300', 'm', 'Meier', 'Anton', '1960-01-17', 'St. Pauli 7', '20345', 'Hamburg');       
INSERT INTO T_Patienten
VALUES ('A518', '106415300',  'w', 'Hagen', 'Nina', '1972-03-12', 'Grugastr. 7', '43001', 'Essen');
INSERT INTO T_Patienten
VALUES ('2345', '45454764',  'm', 'Orth', 'Karl', '1980-04-08', 'Kaufingerstr. 2', '80678', 'München');
INSERT INTO T_Patienten
VALUES ('ZV24', '876508954',  'w', 'Mira', 'Brigitte', '1990-05-01', 'Ebert-Platz 6', '10101', 'Berlin');
INSERT INTO T_Patienten
VALUES ('248', '106415300',  'm', 'Mueller', 'Karl-Heinz', '1967-04-02', 'Waldheim 25', '80876', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('258', '106415300',  'w', 'Maier', 'Gerda', '1996-05-22', 'Im Tal 15', '80765', 'München');
INSERT INTO T_Patienten
VALUES ('2714', '45454764',  'm', 'Huber', 'Fritz', '1957-06-30', 'Werksallee 512', '43012', 'Essen');
INSERT INTO T_Patienten
VALUES ('123', '028983434523',  'm', 'Mair', 'Sepp', '1948-07-16', 'Birkenweg 54', '80281', 'Anzing');
INSERT INTO T_Patienten
VALUES ('429', '106415300',  'w', 'Breitner', 'Paula', '1942-08-11', 'Sedanstr. 60', '80123', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('4711', '564565687',  'm', 'Asam', 'Egon', '1939-09-03', 'Sendlinger Str. 8', '80012', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('5301', '106415300',  'm', 'Sharif', 'Omar', '1954-10-14', 'Bankengasse 51', '60987', 'Frankfurt');
INSERT INTO T_Patienten
VALUES ('611', '564565687',  'd', 'Schmitt', 'Emil', '1966-11-26', 'Arabellastr. 4', '80234', 'München');
INSERT INTO T_Patienten
VALUES ('695', '1637852973',  'm', 'Strauss', 'Franz-J.', '1952-12-05', 'Waldeslust 20', '80345', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('NL805', '564565687',  'm', 'Huber', 'Xaver', '1992-11-09', 'An der Isar 25', '80456', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('855', '564565687',  'm', 'Stradivari', 'Giuseppe', '1949-01-10', 'Dachstr. 9', '80567', 'Muenchen');
INSERT INTO T_Patienten
VALUES ('94', '1637852973',  'w', 'Lamberti', 'Antonia', '1962-02-28', 'Friedensweg 21', '10222', 'Berlin');


CREATE TABLE T_Impfstoffe
(
    P_Impfstoff_ID CHAR(20) NOT NULL,
    Bezeichnung CHAR(40),
    Hersteller CHAR(40),
    Dosierung CHAR(10),
    EU_Zulassungsdatum DATETIME
);

ALTER TABLE T_Impfstoffe
ADD CONSTRAINT PK_Impfstoffe PRIMARY KEY (P_Impfstoff_ID);

INSERT INTO T_Impfstoffe
VALUES ('BNT162b2', 'COMIRNATY', 'BioNTech Manufacturing GmbH', '0,3 ml', '2020-12-21');
INSERT INTO T_Impfstoffe
VALUES ('Ad26.COV2.S', 'COVID-19 Vaccine Janssen', 'Janssen-Cilag International NV', '0,5 ml', '2021-03-11');
INSERT INTO T_Impfstoffe
VALUES ('mRNA-1273', 'COVID-19 Vaccine Moderna', 'Moderna Biotech Spain, S.L.', '0,5 ml', '2021-01-06');
INSERT INTO T_Impfstoffe
VALUES ('ChAdOx1', 'Vaxzevria', 'Astra­Zeneca AB, Schweden', '0,5 ml', '2021-01-29');

CREATE TABLE T_Impfdosen
(
    P_Dosis_ID CHAR(10) NOT NULL,
    F_Impfstoff_ID CHAR(20) NOT NULL,
    F_Versicherungsnr CHAR(20),
    F_Krankenkasse CHAR(20),
    Herstellungsdatum DATETIME,
    Impfdatum DATETIME,
    Ort CHAR(20),
    Arzt CHAR(20)
);

ALTER TABLE T_Impfdosen
ADD CONSTRAINT PK_Impfdosen PRIMARY KEY (P_Dosis_ID);
ALTER TABLE T_Impfdosen
ADD CONSTRAINT FK_Impfdosen_zu_Impfstoffen FOREIGN KEY (F_Impfstoff_ID) REFERENCES T_Impfstoffe (P_Impfstoff_ID);
ALTER TABLE T_Impfdosen
ADD CONSTRAINT FK_Impfdosen_zu_Patienten FOREIGN KEY (F_Versicherungsnr, F_Krankenkasse) REFERENCES T_Patienten (P_Versicherungsnr, PF_Krankenkasse);

INSERT INTO T_Impfdosen
VALUES ('203010748', 'ChAdOx1', '2714', '45454764', '2021-03-10', '2021-03-15', 'Tempelhof', 'Lauterbach');
INSERT INTO T_Impfdosen
VALUES ('206546548', 'ChAdOx1', '123', '106415300', '2021-03-10', '2021-03-15', 'Tempelhof', 'Specht');
INSERT INTO T_Impfdosen
VALUES ('00U8G748', 'BNT162b2', '4711', '564565687', '2021-03-10', '2021-03-17', 'Arena', 'Borges');
INSERT INTO T_Impfdosen
VALUES ('10765748', 'BNT162b2', '429', '106415300', '2021-03-02', '2021-03-11', 'Messe', 'Krause');
INSERT INTO T_Impfdosen
VALUES ('3036576658', 'mRNA-1273', '855', '564565687', '2021-04-03', '2021-04-15', 'Eisstadion', 'Winter');
INSERT INTO T_Impfdosen
VALUES ('00X8K276', 'BNT162b2', '4711', '564565687', '2021-03-28', '2021-04-07', 'Arena', 'Grammel');
