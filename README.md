# Soft-Body Simulation
This project was born out of my desire to experiment, learn, and improve as a programmer. Since I have an interest in physics in video games, I decided to create an implementation of a softbody simulation using code in Unity.

# Step 1: What is a Soft-body?
_"Soft-body dynamics is a field of computer graphics that focuses on visually realistic physical simulations of the motion and properties of deformable objects (or soft bodies)."_     [-Wikipedia](https://en.wikipedia.org/wiki/Soft-body_dynamics)

Once I understood what a soft-body was, I began researching how to create one, and I came across the game "JELLYCAR." Its main mechanics are based on soft-body physics, and thanks to [Walaber Entertainment's video](https://www.youtube.com/watch?v=3OmkehAJoyo&t=52s&ab_channel=WalaberEntertainment), I started grasping the practical aspects of soft-body behavior.

![Captura de pantalla 2023-07-26 202548](https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/d8e8dc5e-485d-4193-9d2a-392fddff71cf)

I continued my research and found a video by [Gonkee](https://www.youtube.com/watch?v=kyQP4t_wOGI&t=201s&ab_channel=Gonkee), which helped me fully understand how I could integrate a soft-body physics simulation into my code.
The video explained how each edge/face of the object is formed by nodes that are connected to each other through springs. By applying Hooke's law, we can measure the spring force and, consequently, adjust the stiffness and damping of the soft-body.

![Captura de pantalla 2023-07-20 171028](https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/3daf0c93-a3c8-434e-861e-c04c33ad35c0)
![Captura de pantalla 2023-07-20 171123](https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/b3a0681e-3b68-4f98-bd60-7bfb3172f755)
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/4a2afa90-bf3f-40b9-b3ae-81d3da8b637c /> 
</p>

Once the Hooke's law was researched and the logic behind a soft-body was understood, we began with the implementation and testing within Unity.

# Step 2 - Integration & Testing
First, I conducted a test using Unity components to learn how it worked in a real scenario. (I used Configurable Joint, Spring Joint, and a Rigidbody for each node).
Once I understood the functioning, I created the first version of the code to simulate a rope. Although it worked, I wasn't satisfied with its unstable behavior. As a solution, I decided to use the Fixed Joint component, which allows connecting one object to another through its Rigidbody, ensuring that the rope's elements didn't separate.
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/d52efb5d-9529-4443-b4e4-d8c10f433bb8 /> 
</p>

It was a good start, but it wasn't what I wanted. Therefore, by modifying the initial code, I began my first tests in 3D.
The code was designed to make the figure modular so that I could observe the behavior of each node. Each node of the figure calculates the spring force in relation to its adjacent nodes.

<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/ef7b21ff-f3d7-4404-8c73-4601f7386f08 /> 
</p>

_*Note:* You must manually add the adjacent nodes to the public list (AdjacentNodes), and the code will connect the initial node with the nodes in the list and perform all the calculations._

I continued with tests on objects of different shapes and sizes to improve the visual aspect. Although I managed to create a functional 2x2 cube, I realized that using Unity's Fixed Joint severely limited the soft-body's behavior.
However, I discovered that the Fixed Joint component worked exceptionally well for creating horizontal springs.
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/45af57c5-96cc-41d8-aa66-3714d019ac68 /> 
</p>

Even though it looked good, it wasn't exactly what I was aiming for. To achieve a fully functional soft-body, I modified the code once again, this time utilizing the Spring Joint component. Drawing on the knowledge I had gained from previous experiments, I was able to create a perfectly functional soft-body with the added benefit of being modular.
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/629b2c62-a31f-49d8-a031-03765f1bfea2 /> 
</p>
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/0074f9ae-8b06-40b2-914f-87c8c1088302 /> 
</p>
<p align="center"> 
 <img src= https://github.com/Carkem1x/SoftBody_Simulation/assets/45597315/93b75ddd-c54c-49ac-94f1-80ea7d69f0e8 /> 
</p>

# Step 3: What´s next?
You can use this repository in Unity 2021 or higher
I will leave the code modular, allowing you to experiment with different shapes. The project is free to use but if you use it, don't forget to mention me :) 

# Author´s note
Learn more about these and other projects on my portfolio: [https://alancarpinteyro.myportfolio.com/work](https://alancarpinteyro.myportfolio.com/work)

If you have any questions or suggestions about this proyect, please feel free to contact with me at aecg117@gmail.com.

*-Alan Carpinteyro*

