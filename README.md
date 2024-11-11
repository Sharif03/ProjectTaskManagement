# Project Management System

Welcome to the **Project Management System** repository, a streamlined platform for managing projects and tasks with essential features such as CRUD operations, search, filtering, and task approvals.

## 📚 Project Overview

This application is built to efficiently handle **Project** and **Task Management** needs. Users can create and organize projects, assign tasks, track their status, and leverage powerful search and filtering tools for easy management.

## 🌐 API Endpoints

Explore the API endpoints available for seamless integration and data manipulation:

![Project_API_1](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/api_exposed_1.png)
![Project_API_2](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/api_exposed_2.png)

## ⚙️ Core Functionality

### 1. Project & Task Management
   - **Projects**: Perform full CRUD operations to create, update, view, and delete projects.
     
     - View Project List
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_list_1.png)

     - Create Project
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_create_1.png)
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_create_2.png)

     - Edit Project
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_edit_1.png)

     - Delete Project
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_delete_1.png)
     
   - **Tasks**: Manage tasks with CRUD capabilities, assign tasks to specific projects, and ensure automatic task deletion when a project is deleted.

     - View Task List
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_list_1.png)

     - Create Task
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_create_1.png)
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_create_2.png)

     - Edit Task
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_edit_1.png)

     - Delete Task
     ![CRUD on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_delete_1.png)

   - **Approval Status**: Each task has an approval mechanism. Approved tasks are protected from deletion.
     ![Task Approval](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_approve_1.png)
     ![Task Approval](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_approve_2.png)
     ![Task Approval](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_approve_3.png)

### 2. Search and Filtering
   - **Search**: Integrated search for both Projects and Tasks within their respective lists.
     - Search for Projects within it's respective lists.
     ![Search on Project](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/project_search_1.png)

     - Search for Tasks within it's respective lists.
     ![Search on Task](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_search_1.png)
     
   - **Multi-Select Dropdown**: Filter tasks based on assigned projects with a user-friendly, multi-select dropdown.
     ![Multi-Select Dropdownt](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_multiselect_1.png)
     ![Multi-Select Dropdownt](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_multiselect_2.png)
     
### 3. Pagination
   - **Task Lists**: Navigate through Tasks efficiently with pagination support for an improved user experience.
     ![Paging on Task](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_paging_1.png)
     ![Paging on Task](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_paging_2.png)

### 4. Cascade Deletion
   - If a project is deleted, all tasks assigned to that project are automatically removed, simplifying project management.
     ![Multi_Task Delete](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_multidelete_1.png)
     ![Multi_Task Delete](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_multidelete_2.png)
     ![Multi_Task Delete](https://github.com/Sharif03/ProjectTaskManagement/blob/main/assets/task_multidelete_3.png)

## 📋 Features Planned (TODO)
- **Task-Wise Project Graph**: Visualize project progress and task allocation with graphical insights.
- **Project Dashboard**: Centralized dashboard for a comprehensive overview of projects, tasks, and key metrics.
- **Export Project Profile**: Export project data and summaries for reporting and sharing.

---
