# hospital_management
This is our c# group work project 


# 🏥 Hospital Management System

A C#-based desktop application developed as part of the **Object Oriented Programming 2 (CSC 2210)** course at **American International University–Bangladesh (AIUB)**, Department of Computer Science.

---

## 👨‍💻 Team Members

| Name | Student ID |
|------|-----------|
| Md Yousuf Sarkar | 23-55173-3 |
| Fazly Rahi | 23-55174-3 |
| Faysal Talukder | 23-55257-3 |

> **Supervised by:** Dr. Md. Iftekharul Mobin  
> **Section:** M | **Semester:** Summer 2025–2026

---

## 📌 Introduction

The **Hospital Management System (HMS)** is a Windows Forms desktop application built with **C#** that automates the day-to-day operations of a small to medium-sized hospital or clinic. It replaces manual paper-based processes with a centralized digital system for managing doctors, patients, diagnoses, and secure admin access.

### Problem Statement

Many small clinics face the following issues:
- Doctor and patient data stored manually in registers or loose files
- Difficulty in quickly retrieving patient information or medical history
- No centralized view of which doctor treated which patient
- Risk of data loss, duplication, and human error from manual handling

### Objectives

1. Design and implement a user-friendly desktop application for hospital information management
2. Provide a secure login system for the administrator
3. Manage doctor information (add, update, delete, view)
4. Manage patient information (add, update, delete, view)
5. Manage diagnosis records linked with patients (symptoms, tests, medicines)

---

## 🛠️ Project Details

| Property | Details |
|----------|---------|
| **Project Name** | Hospital Management System |
| **Category** | Visual Programming Project |
| **Language** | C# |
| **IDE** | Microsoft Visual Studio |
| **Database** | SQL Server (via T-SQL) |

---

## ✨ Features

### 👨‍⚕️ Doctor Module
| Field | Description |
|-------|-------------|
| Doctor ID | Unique identifier for each doctor |
| Doctor Name | Full name of the doctor |
| Gender | Doctor's gender |
| Years of Experience | Total years in practice |
| Department | Medical department the doctor belongs to |

### 🧑‍🤝‍🧑 Patient Module
| Field | Description |
|-------|-------------|
| Patient ID | Unique identifier for each patient |
| Patient Name | Full name of the patient |
| Address | Residential address |
| Phone No | Contact number |
| Gender | Patient's gender |
| Blood Group | Patient's blood group |
| Major Disease | Primary medical condition |

### 🩺 Diagnosis Module
| Field | Description |
|-------|-------------|
| Diagnosis ID | Unique identifier for each diagnosis record |
| Patient ID | Foreign key linking to a specific patient |
| Patient Name | Name of the diagnosed patient |
| Symptoms | Symptoms reported by the patient |
| Diagnostic Test | Tests performed or recommended |
| Medicines | Prescribed medications |

### 🔐 Admin / Login Module
| Field | Description |
|-------|-------------|
| Admin | Administrator username |
| Password | Secure password for system access |

---

## 🗄️ Database Schema (SQL)

### Patient Table
```sql
CREATE TABLE [dbo].[Patient](
    [PId]           INT            NOT NULL,
    [PName]         NVARCHAR(100)  NOT NULL,
    [PAddress]      NVARCHAR(255)  NOT NULL,
    [PAge]          INT            NOT NULL,
    [PPhone]        NVARCHAR(15)   NOT NULL,
    [PGen]          NVARCHAR(10)   NOT NULL,
    [BloodGroup]    NVARCHAR(10)   NOT NULL,
    [MajorDisease]  NVARCHAR(255)  NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED ([PId] ASC)
);
```

### Doctor Table
```sql
CREATE TABLE [dbo].[Doctor](
    [DocId]       INT            NOT NULL,
    [DocName]     NVARCHAR(100)  NOT NULL,
    [DocGen]      NVARCHAR(10)   NOT NULL,
    [Department]  NVARCHAR(100)  NOT NULL,
    [Experience]  INT            NOT NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED ([DocId] ASC)
);
```

### Diagnosis Table
```sql
CREATE TABLE [dbo].[Diagnosis](
    [DId]            INT            NOT NULL,
    [PatientId]      INT            NOT NULL,
    [PatientName]    NVARCHAR(100)  NOT NULL,
    [Symptoms]       NVARCHAR(255)  NOT NULL,
    [DiagnosticTest] NVARCHAR(255)  NOT NULL,
    [Medicines]      NVARCHAR(255)  NOT NULL,
    CONSTRAINT [PK_Diagnosis] PRIMARY KEY CLUSTERED ([DId] ASC),
    CONSTRAINT [FK_Diagnosis_Patient] FOREIGN KEY ([PatientId])
        REFERENCES [dbo].[Patient] ([PId])
);
```

### Admin Table
```sql
CREATE TABLE [dbo].[Admin](
    [AdminId]   INT IDENTITY(1,1) NOT NULL,
    [Username]  NVARCHAR(50)      NOT NULL,
    [Password]  NVARCHAR(50)      NOT NULL,
    CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED ([AdminId] ASC)
);
```

---

## 📊 ER Diagram Overview

The system contains four main entities:

- **Doctor** — identified by `Doctor_ID`; stores name, gender, experience, and department
- **Patient** — identified by `Patient_ID`; stores personal info, contact, blood group, and disease
- **Diagnosis** — identified by `Diagnosis_ID`; linked to Patient via `Patient_ID` (FK)
- **Login** — stores Admin credentials for secure access

The **"Treated For"** relationship indicates that a Patient can have multiple Diagnosis records, while each Diagnosis belongs to exactly one Patient.

### Normalization (2NF)

**Final normalized tables:**
- `Doctor(Doctor_ID PK, Doctor_Name, Gender, Experience, Department)`
- `Patient(Patient_ID PK, Patient_Name, Phone_No, Address, Blood_Group, Major_Disease)`
- `Diagnosis(Diagnosis_ID PK, Patient_ID FK, Symptoms, Test, Medicines)`

---

## 🔄 System Flow (Activity Diagram Summary)

```
User Login
    │
    ▼
Is Admin?
 ├── YES → Manage Users & Control System Operations
 └── NO  → Access Patient Records
              ├── Schedule Appointment
              ├── Enter Diagnosis
              └── View Patient History
    │
    ▼
  END
```

---

## 👥 Use Case Summary

| Actor | Use Cases |
|-------|-----------|
| **Admin** | Manage Users, Manage Patient Info |
| **Doctor** | Schedule Patient Checkup, Enter Diagnosis Details, View Patient History |
| **Patient** | Schedule Checkup, View Medical History |

---

## ✅ Conclusion

- Successfully developed and implemented using **C# Windows Forms** with a SQL database backend
- Covers all core modules: Doctor, Patient, Diagnosis, and Admin Login
- Implements **ER modeling** and **2NF normalization** to reduce data redundancy
- Follows **Object-Oriented Programming** principles including event-driven programming
- Supports three user roles: **Administrator**, **Doctor**, and **Patient**
- Reduces manual effort, minimizes errors, and improves overall hospital management efficiency

### 🚀 Future Enhancements
- Billing and payment automation
- Advanced reporting and analytics
- Web or mobile platform expansion

---



