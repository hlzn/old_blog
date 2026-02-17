    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (1, 'Aliens Land in Central Park', 'Eyewitnesses report seeing strange lights and figures in Central Park.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/aliens_urmz0n.jpg', '2025-01-05', true, '{Aliens, UFOs}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (2, 'New Superfood Discovered in the Amazon', 'Scientists claim a new superfood found in the Amazon can extend human lifespan.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633665/superfood_gvznlz.jpg', '2025-01-08', true, '{Health, Food}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (3, 'Worlds First Flying Car Hits the Market', 'A new flying car model is now available for purchase, promising to revolutionize transportation.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/flyingcar_koipke.jpg', '2025-01-09', true, '{Technology, Transportation}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (4, 'Quantum Computers Solve Longstanding Math Problem', 'Quantum computers have successfully solved a math problem that has puzzled scientists for decades.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/mathproblem_ooomw3.jpg', '2025-01-10', true, '{Technology, Science}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (5, 'Volcano Erupts in the Middle of a City', 'A sudden volcanic eruption has caused chaos in the middle of a bustling city.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633665/volcano_j3goji.jpg', '2024-01-19', true, '{Natural Disasters}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (6, 'Robot Dog Wins Best in Show at Dog Show', 'A robot dog has won the top prize at a prestigious dog show, beating out real dogs.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/robotdog_w0uh6d.webp', '2024-11-19', true, '{Technology, Animals}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (7, 'Time Traveler Claims to Have Visited Ancient Rome', 'A self-proclaimed time traveler claims to have visited ancient Rome and brought back artifacts.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633665/traveler_vlm0xd.png', '2025-01-11', true, '{Time Travel}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (8, 'Giant Sequoia Tree Discovered to Be 5,000 Years Old', 'Scientists have discovered a giant sequoia tree that is over 5,000 years old.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/sequoia_n3abbp.webp', '2025-01-19', true, '{Nature, Science}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (9, 'Underwater City Found in the Bermuda Triangle', 'Divers have discovered an ancient underwater city in the Bermuda Triangle.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633665/underwater_thxjpp.jpg', '2025-01-19', true, '{Mystery, History}', '2023-10-01', '2023-10-01');

    insert into "BlogPosts" ("Id", "Title", "Preview", "PreviewImageSource", "PublishedAt", "IsPublic", "Tags", "CreatedAt", "UpdatedAt")
    values (10, 'Mars Rover Discovers Signs of Ancient Life', 'The Mars rover has found evidence of ancient microbial life on the red planet.', 'https://res.cloudinary.com/dlalpk5ff/image/upload/c_thumb,w_200,g_face/v1746633664/mars_vxujgj.jpg', '2021-01-19', true, '{Space, Science}', '2023-10-01', '2023-10-01');

insert into "BlogPostSections" ("BlogPostId", "Index", "ContentType", "Content", "CreatedAt", "UpdatedAt")
    values 
    (1, 1, 'Text', 'Aliens have landed in Central Park, according to eyewitness reports. Several people claim to have seen strange lights and figures in the park late last night. Some witnesses describe the aliens as tall, green creatures with multiple eyes, while others say they saw smaller beings with elongated limbs. The NYPD has increased patrols in the area and is urging anyone with information to come forward.', NOW(), NOW()),
    (1, 2, 'Text', 'The authorities have yet to confirm the reports, but many are speculating about the possibility of extraterrestrial visitors. Scientists are also intrigued by the news and are eager to investigate further. Could this be the first contact with intelligent life from another planet? Only time will tell.', NOW(), NOW()),
    (2, 3, 'Text', 'Scientists have discovered a new superfood in the Amazon rainforest that they claim can extend human lifespan. The plant, known as "Eternal Berry," is said to be rich in antioxidants and other nutrients that promote longevity and overall health.', NOW(), NOW()),
    (2, 4, 'Text', 'Researchers have conducted preliminary studies on the berry and found promising results in animal trials. They are now planning to conduct human trials to determine the full extent of its health benefits. If successful, the Eternal Berry could revolutionize the health and wellness industry and change the way we think about aging.', NOW(), NOW()),
    (3, 5, 'Text', 'The worlds first flying car is now available for purchase, promising to revolutionize transportation as we know it. The new model, called "SkyDrive," is a hybrid vehicle that can both drive on roads and fly in the air.', NOW(), NOW()),
    (3, 6, 'Text', 'It is equipped with advanced technology that allows it to take off and land vertically, making it ideal for urban environments. The SkyDrive has a range of 300 miles and can reach speeds of up to 100 mph in the air.', NOW(), NOW()),
    (4, 7, 'Text', 'Quantum computers have achieved a major breakthrough by solving a math problem that has puzzled scientists for decades. The problem, known as the "Traveling Salesman Problem," involves finding the most efficient route for a salesman to visit a set of cities and return to the starting point.', NOW(), NOW()),
    (4, 8, 'Text', 'It is a notoriously difficult problem to solve, even for the most powerful classical computers. However, a team of researchers using a quantum computer has found an optimal solution to the problem in record time.', NOW(), NOW()),
    (5, 9, 'Text', 'A sudden volcanic eruption has caused chaos in the middle of a bustling city, sending residents fleeing for safety. The volcano, located in the heart of the city, erupted without warning, spewing ash and lava into the air.', NOW(), NOW()),
    (5, 10, 'Text', 'The eruption has caused widespread damage to buildings and infrastructure, and authorities are working to evacuate residents and contain the damage. Scientists are monitoring the situation closely and are warning of the potential for further eruptions.', NOW(), NOW()),
    (6, 11, 'Text', 'A robot dog has made history by winning the top prize at a prestigious dog show, beating out real dogs in the competition. The robot, named "Rover," wowed judges with its lifelike appearance, agility, and intelligence.', NOW(), NOW()),
    (6, 12, 'Text', 'Rover is equipped with advanced artificial intelligence and sensors that allow it to perform tasks and interact with its environment like a real dog. The victory has sparked debate among dog enthusiasts about the role of technology in pet ownership.', NOW(), NOW()),
    (6, 13, 'Text', 'Some argue that robots should not be allowed to compete against real animals, while others see it as a sign of progress and innovation in the field of robotics.', NOW(), NOW()),
    (7, 14, 'Text', 'A self-proclaimed time traveler has made headlines by claiming to have visited ancient Rome and brought back artifacts from the past. The traveler, who goes by the name "Alex," says he used a time machine to travel back in time and witness the glory of the Roman Empire.', NOW(), NOW()),
    (7, 15, 'Text', 'He claims to have interacted with ancient Romans, witnessed gladiator battles, and even met Julius Caesar himself. Alex has presented several artifacts as proof of his journey, including coins, pottery, and jewelry from ancient Rome.', NOW(), NOW()),
    (8, 16, 'Text', 'Scientists have made a remarkable discovery in a remote forest, finding a giant sequoia tree that is over 5,000 years old. The tree, named "Old Sequoia," is one of the oldest living organisms on Earth and has survived for millennia through natural disasters and changing climates.', NOW(), NOW()),
    (8, 17, 'Text', 'Researchers have used advanced dating techniques to determine the age of the tree and are studying its growth patterns to learn more about its longevity. The discovery of Old Sequoia has sparked interest in the conservation of ancient trees and ecosystems.', NOW(), NOW()),
    (9, 18, 'Text', 'Divers exploring the depths of the Bermuda Triangle have made a stunning discovery: an ancient underwater city that has been hidden for centuries. The city, known as "Atlantis II," is believed to be a lost civilization that thrived in the region thousands of years ago.', NOW(), NOW()),
    (9, 19, 'Text', 'The ruins of Atlantis II are remarkably well-preserved, with intact buildings, streets, and artifacts that offer a glimpse into the citys past. Archaeologists are now working to uncover the secrets of the underwater city and piece together its history.', NOW(), NOW()),
    (10, 20, 'Text', 'The Mars rover has made a groundbreaking discovery, finding evidence of ancient microbial life on the red planet. The rover, named "Explorer," has been exploring the Martian surface for several years and recently uncovered fossilized remains of microorganisms in a rock sample.', NOW(), NOW()),
    (10, 21, 'Text', 'The discovery has sent shockwaves through the scientific community and raised questions about the possibility of life on Mars. Researchers are now analyzing the samples in more detail to learn more about the ancient microbes and their potential significance.', NOW(), NOW()),
    (10, 22, 'Text', 'The discovery of ancient life on Mars has opened up new avenues for exploration and has renewed interest in the search for extraterrestrial life in the universe.', NOW(), NOW());



insert into "BlogPostSections" ("BlogPostId", "Index", "ContentType", "Content", "CreatedAt", "UpdatedAt")
    values
    (1, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/aliens_urmz0n.jpg', now(), now()),
    (2, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633665/superfood_gvznlz.jpg', now(), now()),
    (3, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/flyingcar_koipke.jpg', now(), now()),
    (4, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/mathproblem_ooomw3.jpg', now(), now()),
    (5, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633665/volcano_j3goji.jpg', now(), now()),
    (6, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/robotdog_w0uh6d.webp', now(), now()),
    (7, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633665/traveler_vlm0xd.png', now(), now()),
    (8, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/sequoia_n3abbp.webp', now(), now()),
    (9, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633665/underwater_thxjpp.jpg', now(), now()),
    (10, 0, 'Image', 'https://res.cloudinary.com/dlalpk5ff/image/upload/v1746633664/mars_vxujgj.jpg', now(), now());