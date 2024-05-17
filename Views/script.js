const url = "https://localhost:7136";

document
  .getElementById("getAllUsersBtn")
  .addEventListener("click", getAllUsers);
document
  .getElementById("getUserByIdBtn")
  .addEventListener("click", getUserById);
document
  .getElementById("getUserByCompanyBtn")
  .addEventListener("click", getUserByCompany);
document
  .getElementById("getUserByEmailBtn")
  .addEventListener("click", getUserByEmail);
document
  .getElementById("getUserByNameBtn")
  .addEventListener("click", getUserByName);

document.getElementById("addUserForm").addEventListener("submit", addUser);

function getAllUsers() {
  const xhr = new XMLHttpRequest();
  xhr.open("GET", url + "/api/User", true);
  xhr.onload = function () {
    if (this.status === 200) {
      displayResult(JSON.parse(this.responseText));
    } else {
      console.error("Error fetching all users:", this.statusText);
    }
  };
  xhr.onerror = function () {
    console.error("Request error");
  };
  xhr.send();
}

function getUserById() {
  const userId = document.getElementById("inputId").value;
  if (userId) {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", `${url}/api/User/user/id/${userId}`, true);
    xhr.onload = function () {
      if (this.status === 200) {
        displayResult(JSON.parse(this.responseText));
      } else {
        console.error(`Error fetching user by ID ${userId}:`, this.statusText);
      }
    };
    xhr.onerror = function () {
      console.error("Request error");
    };
    xhr.send();
  } else {
    alert("Please enter a user ID");
  }
}

function getUserByCompany() {
  const company = document.getElementById("inputCompany").value;
  if (company) {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", `${url}/api/User/user/company/${company}`, true);
    xhr.onload = function () {
      if (this.status === 200) {
        displayResult(JSON.parse(this.responseText));
      } else {
        console.error(
          `Error fetching user by company ${company}:`,
          this.statusText
        );
      }
    };
    xhr.onerror = function () {
      console.error("Request error");
    };
    xhr.send();
  } else {
    alert("Please enter a company name");
  }
}

function getUserByName() {
  const name = document.getElementById("inputName").value;
  if (name) {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", `${url}/api/User/user/name/${name}`, true);
    xhr.onload = function () {
      if (this.status === 200) {
        displayResult(JSON.parse(this.responseText));
      } else {
        console.error(`Error fetching user by name ${name}:`, this.statusText);
      }
    };
    xhr.onerror = function () {
      console.error("Request error");
    };
    xhr.send();
  } else {
    alert("Please enter a valid name");
  }
}

function getUserByEmail() {
  const email = document.getElementById("inputEmail").value;
  if (email) {
    const xhr = new XMLHttpRequest();
    xhr.open("GET", `${url}/api/User/user/email/${email}`, true);
    xhr.onload = function () {
      if (this.status === 200) {
        displayResult(JSON.parse(this.responseText));
      } else {
        console.error(
          `Error fetching user by this email ${email}:`,
          this.statusText
        );
      }
    };
    xhr.onerror = function () {
      console.error("Request error");
    };
    xhr.send();
  } else {
    alert("Please enter a valid email");
  }
}

function addUser(event) {
  event.preventDefault();

  const name = document.getElementById("newUserName").value;
  const email = document.getElementById("newUserEmail").value;
  const company = document.getElementById("newUserCompany").value;
  const personalNumber = document.getElementById("newUserPersonalNumber").value;
  const businessNumber = document.getElementById("newUserBusinessNumber").value;

  const user = {
    name: name,
    email: email,
    company: company,
    personalNumber: personalNumber,
    businessNumber: businessNumber,
  };

  const xhr = new XMLHttpRequest();
  xhr.open("POST", url + "/api/User", true);
  xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
  xhr.onload = function () {
    if (this.status === 200 || this.status === 201) {
      displayResult(JSON.parse(this.responseText));
      document.getElementById("addUserForm").reset();
    } else {
      console.error("Error adding user:", this.statusText);
    }
  };
  xhr.onerror = function () {
    console.error("Request Error");
  };
  xhr.send(JSON.stringify(user));
}

function displayResult(data) {
  const resultSection = document.getElementById("result");
  resultSection.textContent = JSON.stringify(data, null, 2);
}
