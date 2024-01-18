// Obtener el valor del input invisible que contiene las IDs separadas por coma
var idsString = document.getElementById("courseIDs").value;

// Separar las IDs en un array
var ids = idsString.split(',');

// Variable para almacenar los nombres de los cursos
var courses = [];

// Función para obtener el nombre del curso por su ID
function obtenerNombreCursoPorId(courseId) {
    return fetch(`/Courses/GetNameById/${courseId}`)
        .then(response => response.json())
        .then(data => {
            return { name: data.Name, url: data.Url, ECTS: data.ECTS };
        })
        .catch(error => console.error('Error:', error));
}

// Función para manejar la obtención de los nombres de los cursos
async function cargarCourses(ids) {
    try {
        for (let i = 0; i < ids.length; i++) {
            const data = await obtenerNombreCursoPorId(ids[i]);
            const nombreCurso = data.name;
            const url = data.url;
            const ECTS = data.ECTS
            curso = { id: ids[i], name: nombreCurso, url: url, ECTS: ECTS };

            var courseAlreadyPresent = courses.find(function (json) {
                return json.id === curso.id;
            });

            // If the course is already added we won't add it again
            if (!courseAlreadyPresent) {
                courses.push(curso)
                agregarCourse(curso)
            }
        }
        console.log(courses);
        actualizarCampoOculto();
    } catch (error) {
        console.error('Error:', error);
    }
}

function cargarCarrito() {
    let coursesCarrito = getCarrito();
    cargarCourses(coursesCarrito);
    console.log(coursesCarrito)
    emptyCarrito();
}

function agregarCourse(course) {

    if (course.name !== "") {
        courseList = document.getElementById("courseList");

        // Crear elemento de lista
        var listItem = document.createElement("li");
        listItem.innerHTML = course.name + " (" + course.ECTS + " ECTS)"
        listItem.style.marginBottom = "5px"

        var buttonsDiv = document.createElement("div");

        var detailsButton = document.createElement("a");
        detailsButton.innerHTML = "Details";
        detailsButton.classList.add("btn");
        detailsButton.classList.add("btn-primary");
        detailsButton.setAttribute("href", course.url);
        detailsButton.setAttribute("target", "_blank");

        listItem.appendChild(buttonsDiv);
        buttonsDiv.appendChild(detailsButton);

        if (!courseList.dataset.nobuttons) {
            // Botón para borrar el curso
            var deleteButton = document.createElement("button");
            deleteButton.innerHTML = "Delete";
            deleteButton.classList.add("btn");
            deleteButton.classList.add("btn-danger");
            deleteButton.style.marginLeft = "5px";
            deleteButton.onclick = function () {
                borrarCourse(listItem, course.id);
            };

            buttonsDiv.appendChild(deleteButton);
        }

        listItem.classList.add("list-group-item")
        listItem.style.display = "flex";
        listItem.style.justifyContent = "space-between";
        listItem.style.alignItems = "center";

        // Agregar el curso a la lista
        courseList.appendChild(listItem);

    }
}

function borrarCourse(item, courseID) {
    var listaCourses = document.getElementById("courseList");

    courses = courses.filter(function (json) {
        return json.id !== courseID;
    });

    listaCourses.removeChild(item);

    // Guardar la lista actualizada en el campo oculto
    actualizarCampoOculto();

}

function actualizarCampoOculto() {
    var courseIDs = courses.map(function (curso) {
        return curso.id;
    });

    // Convertir el array a una cadena separada por comas
    var coursesString = courseIDs.join(",");

    console.log(coursesString)

    // Actualizar el valor del campo oculto
    document.getElementById("courseIDs").value = coursesString;
}

cargarCourses(ids);