import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import RequireAuth from "./RequireAuth";

export default {
    title: 'Components/RequireAuth',
    component: RequireAuth,
    argTypes: {},
} as ComponentMeta<typeof RequireAuth>;

const Template: ComponentStory<typeof RequireAuth> = ({...args}) => {
    return <RequireAuth {...args} />;
};

export const Default = Template.bind({});