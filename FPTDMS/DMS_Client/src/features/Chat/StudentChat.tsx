import React, { useCallback, useEffect, useState } from 'react';
import Talk from 'talkjs';
import { Session, Chatbox } from '@talkjs/react';
import axios from 'axios';
import { User } from '../../models/Profile';


const StudentChat: React.FC = () => {
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const userId = localStorage.getItem('user_id');
        const response = await axios.get<User>(`https://localhost:7777/api/User/${userId}`);
        setUser(response.data);
      } catch (error) {
        console.error('Failed to fetch user data:', error);
      }
    };

    fetchUserData();
  }, []);

  const syncUser = useCallback(() => {
    if (user) {
      return new Talk.User({
        id: user.id,
        name: `${user.firstName} ${user.lastName}`,
        email: user.email,
        photoUrl: 'photo_url',
        role: 'student',
      });
    }
    return null;
  }, [user]);

  const syncConversation = useCallback(
    (session: { getOrCreateConversation: (arg0: string) => any; me: any }) => {
      const conversation = session.getOrCreateConversation(
        Talk.oneOnOneId(session.me, 'admin_id')
      );

      const other = new Talk.User({
        id: 'admin_id',
        name: 'Admin',
        email: 'admin@example.com',
        photoUrl: 'admin_photo_url',
        role: 'admin',
      });

      conversation.setParticipant(session.me);
      conversation.setParticipant(other);

      return conversation;
    },
    []
  );

  const chatBoxStyle: React.CSSProperties = {
    position: 'fixed',
    bottom: '70px',
    right: '20px',
    width: '350px', 
    height: '500px', 
    boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)',
    zIndex: 1000,
    backgroundColor: 'white',
    borderRadius: '8px',
  };

  if (!user) return <div>Loading...</div>;

  return (
    <Session appId="teExUqPD" syncUser={syncUser as () => Talk.User}>
      <Chatbox
        syncConversation={syncConversation}
        style={chatBoxStyle}
      ></Chatbox>
    </Session>
  );
};

export default StudentChat;
