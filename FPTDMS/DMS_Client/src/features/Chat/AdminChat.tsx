import React, { useEffect, useState } from 'react';
import Talk from 'talkjs';
import ChatIcon from '@mui/icons-material/Chat';
import { IconButton } from '@mui/material';
import axios from 'axios';
import { User } from '../../models/Profile';



const AdminChat: React.FC = () => {
  const [isChatVisible, setIsChatVisible] = useState(false);
  const [student, setStudent] = useState<User | null>(null);
  const [studentPhotoUrl, setStudentPhotoUrl] = useState<string | null>(null);

  useEffect(() => {
    const fetchStudentData = async () => {
      try {
        const userId = localStorage.getItem('user_id');
        const response = await axios.get<User>(`https://localhost:7777/api/User/${userId}`);
        setStudent(response.data);

        // Convert base64 image to Blob URL
        if (response.data.picture) {
          const base64String = response.data.picture;
          const mimeType = base64String.match(/^data:(.*?);base64,/)?.[1] || '';
          const byteCharacters = atob(response.data.picture);
          const byteNumbers = new Array(byteCharacters.length);
          for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
          }
          const byteArray = new Uint8Array(byteNumbers);
          const blob = new Blob([byteArray], { type: mimeType }); // Assuming the image is in PNG format
          const imageUrl = URL.createObjectURL(blob);
          setStudentPhotoUrl(imageUrl);
        }
      } catch (error) {
        console.error('Failed to fetch student data:', error);
      }
    };

    fetchStudentData();
  }, []);

  useEffect(() => {
    if (isChatVisible && student) {
      Talk.ready.then(() => {
        const me = new Talk.User({
          id: 'admin_id', // Unique identifier for the admin
          name: 'Admin',
          email: 'admin@example.com',
          photoUrl: 'admin_photo_url',
          role: 'admin'
        });

        const other = new Talk.User({
          id: student.id, // Unique identifier for the student
          name: `${student.firstName} ${student.lastName}`,
          email: student.email,
          photoUrl: studentPhotoUrl,
          role: 'student'
        });

        const session = new Talk.Session({
          appId: 'teExUqPD',
          me: me
        });

        const conversation = session.getOrCreateConversation(Talk.oneOnOneId(me, other));
        conversation.setParticipant(me);
        conversation.setParticipant(other);

        const inbox = session.createInbox({ selected: conversation });
        inbox.mount(document.getElementById('talkjs-container'));
      });
    }
  }, [isChatVisible, student]);

  return (
    <div>
      <IconButton
        onClick={() => setIsChatVisible(!isChatVisible)}
        style={{
          position: 'fixed',
          bottom: '20px',
          right: '20px',
          backgroundColor: '#007bff',
          color: '#fff',
          borderRadius: '50%',
          width: '60px',
          height: '60px',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          cursor: 'pointer',
          border: 'none',
          boxShadow: '0px 4px 8px rgba(0, 0, 0, 0.1)'
        }}
      >
        <ChatIcon />
      </IconButton>
      {isChatVisible && student && (
        <div
          id="talkjs-container"
          style={{
            position: 'fixed',
            bottom: '80px',
            right: '20px',
            height: '600px',
            width: '400px',
            backgroundColor: '#fff',
            boxShadow: '0px 4px 8px rgba(0, 0, 0, 0.1)',
            borderRadius: '10px',
            overflow: 'hidden'
          }}
        />
      )}
    </div>
  );
};

export default AdminChat;
