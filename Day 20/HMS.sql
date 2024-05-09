USE dbHMS;

CREATE TABLE Doctor(
	doc_id INT PRIMARY KEY,
	doc_name VARCHAR(50),
	specialization VARCHAR(50)
);

CREATE TABLE Patient(
	patient_id INT PRIMARY KEY,
	patient_name VARCHAR(50),
);

CREATE TABLE Appointment(
	appointment_id INT PRIMARY KEY ,
	appointment_date DATETIME,
	doc_id INT,
	patient_id INT,
	CONSTRAINT fk_appointmentdoctor FOREIGN KEY (doc_id) REFERENCES Doctor(doc_id),
	CONSTRAINT fk_appointmentpatient FOREIGN KEY (patient_id) REFERENCES Patient(patient_id),
);

SELECT * FROM Doctor;