-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 13, 2023 at 06:05 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hso`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_creds`
--

CREATE TABLE `admin_creds` (
  `Admin_ID` int(9) NOT NULL,
  `Admin_UserName` char(30) NOT NULL,
  `Admin_Password` char(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin_creds`
--

INSERT INTO `admin_creds` (`Admin_ID`, `Admin_UserName`, `Admin_Password`) VALUES
(1, 'admin', 'admin1234');

-- --------------------------------------------------------

--
-- Table structure for table `consultation_recycledbin`
--

CREATE TABLE `consultation_recycledbin` (
  `conRecycleBinID` int(11) NOT NULL,
  `Patient_StudentNumber` char(11) NOT NULL,
  `Patient_ConsultationDate` date NOT NULL,
  `Patient_ConsultationTime` time NOT NULL,
  `Patient_PhysicalExaminationAndLaboratoryFindings` mediumtext NOT NULL,
  `Patient_DiagnosisAndManagement` mediumtext NOT NULL,
  `Patient_DateEdited` date NOT NULL,
  `Patient_TimeEdited` time NOT NULL,
  `Patient_DateDeleted` date NOT NULL DEFAULT current_timestamp(),
  `Patient_TimeDeleted` time NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `patient_consultation`
--

CREATE TABLE `patient_consultation` (
  `Patient_StudentNumber` char(11) DEFAULT NULL,
  `Patient_ConsultationDate` date NOT NULL DEFAULT curdate(),
  `Patient_ConsultationTime` time NOT NULL DEFAULT curtime(),
  `Patient_PhysicalExaminationAndLaboratoryFindings` mediumtext NOT NULL,
  `Patient_DiagnosisAndManagement` mediumtext NOT NULL,
  `Patient_DateEdited` date NOT NULL DEFAULT curdate(),
  `Patient_TimeEdited` time NOT NULL DEFAULT curtime()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `patient_info`
--

CREATE TABLE `patient_info` (
  `Patient_StudentNumber` char(11) NOT NULL,
  `Patient_LastName` char(30) NOT NULL,
  `Patient_FirstName` char(50) NOT NULL,
  `Patient_MiddleName` char(30) NOT NULL,
  `Patient_Birthdate` date NOT NULL,
  `Patient_Age` int(2) NOT NULL,
  `Patient_Sex` char(10) NOT NULL,
  `Patient_CivilStatus` char(15) NOT NULL,
  `Patient_Address` char(100) NOT NULL,
  `Patient_ContactNumber` char(11) NOT NULL,
  `Patient_ContactPerson` char(100) NOT NULL,
  `Patient_ContactPersonNum` char(11) NOT NULL,
  `Patient_DateRegistered` date NOT NULL DEFAULT curdate(),
  `Patient_College` char(50) NOT NULL,
  `Patient_Course` char(100) NOT NULL,
  `Patient_DateEdited` date NOT NULL DEFAULT curdate(),
  `Patient_TimeEdited` time NOT NULL DEFAULT curtime()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `patient_medicalhistory`
--

CREATE TABLE `patient_medicalhistory` (
  `Patient_StudentNumber` char(11) DEFAULT NULL,
  `Patient_FamilyHistory` mediumtext NOT NULL,
  `Patient_PastMedicalHistory` mediumtext NOT NULL,
  `Patient_HistoryOfAllergies` mediumtext NOT NULL,
  `Patient_DateEdited` date NOT NULL DEFAULT curdate(),
  `Patient_TimeEdited` time NOT NULL DEFAULT curtime()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `patient_recycledbin`
--

CREATE TABLE `patient_recycledbin` (
  `RecycleBinID` int(11) NOT NULL,
  `Patient_StudentNumber` char(11) NOT NULL,
  `Patient_LastName` char(30) NOT NULL,
  `Patient_FirstName` char(50) NOT NULL,
  `Patient_MiddleName` char(30) NOT NULL,
  `Patient_Birthdate` date NOT NULL,
  `Patient_Age` int(2) NOT NULL,
  `Patient_Sex` char(10) NOT NULL,
  `Patient_CivilStatus` char(15) NOT NULL,
  `Patient_Address` char(100) NOT NULL,
  `Patient_ContactNumber` char(11) NOT NULL,
  `Patient_ContactPerson` char(100) NOT NULL,
  `Patient_ContactPersonNum` char(11) NOT NULL,
  `Patient_DateRegistered` date NOT NULL,
  `Patient_College` char(50) NOT NULL,
  `Patient_Course` char(100) NOT NULL,
  `Patient_FamilyHistory` mediumtext NOT NULL,
  `Patient_PastMedicalHistory` mediumtext NOT NULL,
  `Patient_HistoryOfAllergies` mediumtext NOT NULL,
  `Patient_DateEdited` date NOT NULL,
  `Patient_TimeEdited` time NOT NULL,
  `Patient_DateDeleted` date NOT NULL DEFAULT current_timestamp(),
  `Patient_TimeDeleted` time NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_creds`
--
ALTER TABLE `admin_creds`
  ADD PRIMARY KEY (`Admin_ID`),
  ADD UNIQUE KEY `Admin_ID` (`Admin_ID`);

--
-- Indexes for table `consultation_recycledbin`
--
ALTER TABLE `consultation_recycledbin`
  ADD PRIMARY KEY (`conRecycleBinID`);

--
-- Indexes for table `patient_consultation`
--
ALTER TABLE `patient_consultation`
  ADD KEY `Patient_StudentNumber` (`Patient_StudentNumber`);

--
-- Indexes for table `patient_info`
--
ALTER TABLE `patient_info`
  ADD PRIMARY KEY (`Patient_StudentNumber`),
  ADD UNIQUE KEY `Patient_StudentNumber` (`Patient_StudentNumber`);

--
-- Indexes for table `patient_medicalhistory`
--
ALTER TABLE `patient_medicalhistory`
  ADD KEY `Patient_StudentNumber` (`Patient_StudentNumber`);

--
-- Indexes for table `patient_recycledbin`
--
ALTER TABLE `patient_recycledbin`
  ADD PRIMARY KEY (`RecycleBinID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `consultation_recycledbin`
--
ALTER TABLE `consultation_recycledbin`
  MODIFY `conRecycleBinID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `patient_recycledbin`
--
ALTER TABLE `patient_recycledbin`
  MODIFY `RecycleBinID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `patient_consultation`
--
ALTER TABLE `patient_consultation`
  ADD CONSTRAINT `patient_consultation_ibfk_1` FOREIGN KEY (`Patient_StudentNumber`) REFERENCES `patient_info` (`Patient_StudentNumber`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `patient_medicalhistory`
--
ALTER TABLE `patient_medicalhistory`
  ADD CONSTRAINT `patient_medicalhistory_ibfk_1` FOREIGN KEY (`Patient_StudentNumber`) REFERENCES `patient_info` (`Patient_StudentNumber`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
