import datetime
import re
import pandas as pd
from fpdf import FPDF

def load_employees_from_excel():
    try:
        df = pd.read_excel("employee_details.xlsx")
        return df.to_dict('records')
    except FileNotFoundError:
        return []

def calculate_age(dob):
    today = datetime.date.today()
    birthdate = datetime.datetime.strptime(dob, "%Y-%m-%d").date()
    age = today.year - birthdate.year - ((today.month, today.day) < (birthdate.month, birthdate.day))
    return age

def validate_email(email):
    pattern = r'^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$'
    return re.match(pattern, email)

def validate_phone(phone):
    pattern = r'^\d{10}$'
    return re.match(pattern, phone)

def get_employee_details():
    name = input("Enter Name: ")
    dob = input("Enter Date of Birth (YYYY-MM-DD): ")
    while True:
        phone = input("Enter Phone Number: ")
        if validate_phone(phone):
            break
        else:
            print("Invalid phone number. Please enter a 10-digit phone number.")
    while True:
        email = input("Enter Email: ")
        if validate_email(email):
            break
        else:
            print("Invalid email format. Please enter a valid email.")
    age = calculate_age(dob)
    return {'Name': name, 'DOB': dob, 'Phone': phone, 'Email': email, 'Age': age}

def save_to_text(employees):
    with open("employee_details.txt", "w") as file:
        for employee in employees:
            for key, value in employee.items():
                file.write(f"{key}: {value}\n")
            file.write("\n")
    file.close

def save_to_excel(employees):
    df = pd.DataFrame(employees)
    df.to_excel("employee_details.xlsx", index=False)

class PDF(FPDF):
    def header(self):
        self.set_font('Arial', 'B', 12)
        self.cell(0, 10, 'Employee Details', 0, 1, 'C')

    def chapter_title(self, title):
        self.set_font('Arial', 'B', 12)
        self.cell(0, 10, title, 0, 1, 'L')
        self.ln(5)

    def chapter_body(self, body):
        self.set_font('Arial', '', 12)
        self.multi_cell(0, 10, body)
        self.ln()

def save_to_pdf(employees):
    pdf = PDF()
    pdf.add_page()
    pdf.set_font("Arial", size=12)
    line_height = pdf.font_size * 2.5
    col_width = pdf.w / 5.5 
    pdf.set_font('Arial', 'B', 12)
    for key in employees[0].keys():
        pdf.cell(col_width, line_height, key, border=1)
    pdf.ln(line_height)
    for employee in employees:
        pdf.set_font('Arial', '', 12)
        for value in employee.values():
            pdf.cell(col_width, line_height, str(value), border=1)
        pdf.ln(line_height)
    pdf.output("employee_details.pdf")

def main():
    employees = load_employees_from_excel()
    while True:
        print("\nEmployee Details Application")
        print("1. Add Employee")
        print("2. Save Employee Details")
        print("3. Exit")
        choice = input("Enter your choice: ")

        if choice == '1':
            employee_details = get_employee_details()
            employees.append(employee_details)
            print("\nEmployee Details:")
            for key, value in employee_details.items():
                print(f"{key}: {value}")
        elif choice == '2':
            if employees:
                print("\nSelect format to save:")
                print("1. Text File")
                print("2. Excel File")
                print("3. PDF File")
                format_choice = input("Enter your choice: ")
                if format_choice == '1':
                    save_to_text(employees)
                    print("Details saved to text file.")
                elif format_choice == '2':
                    save_to_excel(employees)
                    print("Details saved to Excel file.")
                elif format_choice == '3':
                    save_to_pdf(employees)
                    print("Details saved to PDF file.")
                else:
                    print("Invalid choice. Please select a valid option.")
            else:
                print("No employee details found. Please add employee details first.")
        elif choice == '3':
            save_to_excel(employees)
            break
        else:
            print("Invalid choice. Please enter a valid option.")

if __name__ == "__main__":
    main()
